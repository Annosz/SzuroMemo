using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Services
{
    public class ReminderService
    {
        public ReminderService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public ICollection<ScreeningHeaderDto> GetUrgentScreenings(int userId)
        {
            var record = DbContext.MedicalRecord.Include(m => m.LastScreenings).First(m => m.UserId == userId);

            ICollection<ScreeningHeaderDto> screenings = new List<ScreeningHeaderDto>(); 

            foreach (var screening in DbContext.Screening)
            {
                switch (screening.Name)
                {
                    case "Nőgyógyászati rákszűrés":
                        if (IsCervicalCarcerScreeningNeeded(record))
                            AddScreeningDto(screenings, screening);
                        break;
                    case "Fogászati szűrés":
                        if (IsLastScreeningEarlierThan(record.LastScreenings.FirstOrDefault(l => l.Screening.Name == screening.Name), 6))
                            AddScreeningDto(screenings, screening);
                        break;
                    case "Szemészeti szűrővizsgálat":
                        break;
                    default:
                        if (IsLastScreeningEarlierThan(record.LastScreenings.FirstOrDefault(l => l.Screening.Name == screening.Name), 24))
                            AddScreeningDto(screenings, screening);
                        break;
                }
            }

            return screenings;
        }

        private bool IsCervicalCarcerScreeningNeeded(MedicalRecord record)
        {
            if (record.Gender == MedicalRecord.GenderEnum.Male)
                return false;

            if (IsLastScreeningEarlierThan(record.LastScreenings.FirstOrDefault(l => l.Screening.Name == "Nőgyógyászati rákszűrés"), 18))
                return true;

            return false;
        }

        private static bool IsLastScreeningEarlierThan(LastScreening lastScreening, int month)
        {
            if (lastScreening == null)
                return true;
            if (lastScreening.Time.AddMonths(month) >= DateTime.Now)
                return true;
            return false;
        }

        private static void AddScreeningDto(ICollection<ScreeningHeaderDto> screenings, Entities.Screening screening)
        {
            screenings.Add(new ScreeningHeaderDto
            {
                Name = screening.Name,
                Id = screening.Id
            });
        }
    }
}
