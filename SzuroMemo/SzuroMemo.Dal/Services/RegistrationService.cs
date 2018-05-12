using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Services
{
    public class RegistrationService
    {
        public RegistrationService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public IEnumerable<RegistrationDto> GetRegistratiosnToUser(int userId) =>
            DbContext.Registration.Where(r => r.UserId == userId)
            .Select(r => new RegistrationDto
            {
                Id = r.Id,
                Arrival = r.Arrival,
                OccasionId = r.OccasionId,
                UserId = r.UserId
            });

        public IEnumerable<OccasionDto> GetOccasionsToUser(int userId) =>
            DbContext.Registration.Where(r => r.UserId == userId)
            .Select(r => new OccasionDto
            {
                Id = r.Occasion.Id,
                StartTime = r.Occasion.StartTime,
                EndTime = r.Occasion.EndTime,
                Description = r.Occasion.Description,

                ScreeningId = r.Occasion.Screening.Id,
                Screening = r.Occasion.Screening.Name,
                ReferralNeeded = r.Occasion.Screening.ReferralNeeded,

                HospitalId = r.Occasion.Hospital.Id,
                Hospital = r.Occasion.Hospital.Name,
                Address = r.Occasion.Hospital.Address,
                PictureUrl = r.Occasion.Hospital.PictureUrl,

                RegistrationNum = r.Occasion.Registrations.Count
            });

        public RegistrationDto RegistrateUserToOccasion(int userId, int occasionId)
        {
            var registration = new Registration
            {
                Occasion = DbContext.Occasion.Find(occasionId),
                User = DbContext.Users.Find(userId),
                Arrival = DbContext.Occasion.Find(occasionId).StartTime
            };

            DbContext.Registration.Add(registration);

            DbContext.SaveChanges();

            return new RegistrationDto
            {
                Id = registration.Id,
                Arrival = registration.Arrival,
                UserId = registration.UserId,
                OccasionId = registration.OccasionId
            };
        }

        public RegistrationDto UnregistrateUserFromOccasion(int userId, int occasionId)
        {
            var registration = DbContext.Registration.First(r => r.UserId == userId && r.OccasionId == occasionId);

            DbContext.Registration.Remove(registration);

            DbContext.SaveChanges();

            return new RegistrationDto
            {
                Id = registration.Id,
                Arrival = registration.Arrival,
                UserId = registration.UserId,
                OccasionId = registration.OccasionId
            };
        }
    }
}
