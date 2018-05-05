using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;

namespace SzuroMemo.Dal.Services
{
    public class OccasionService
    {
        public OccasionService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public IEnumerable<OccasionDto> GetOccasions() => DbContext.Occasion
            .Include(o => o.Hospital)
            .Include(o => o.Screening)
            .Include(o => o.Registrations)
            .Select(o => new OccasionDto
            {
                Id = o.Id,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                Description = o.Description,

                ScreeningId = o.Screening.Id,
                Screening = o.Screening.Name,
                ReferralNeeded = o.Screening.ReferralNeeded,

                HospitalId = o.Hospital.Id,
                Hospital = o.Hospital.Name,
                Address = o.Hospital.Address,
                PictureUrl = o.Hospital.PictureUrl,

                RegistrationNum = o.Registrations.Count
            })
            .OrderBy(o => o.StartTime);
    }
}
