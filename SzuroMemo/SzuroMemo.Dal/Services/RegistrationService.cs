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

        public IEnumerable<RegistrationDto> GetRegistrationToUser(int userId) =>
            DbContext.Registration.Where(r => r.UserId == userId)
            .Select(r => new RegistrationDto
            {
                Id = r.Id,
                Arrival = r.Arrival,
                OccasionId = r.OccasionId,
                UserId = r.UserId
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
