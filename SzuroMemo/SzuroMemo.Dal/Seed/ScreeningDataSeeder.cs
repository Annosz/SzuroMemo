using System;
using System.Linq;

namespace SzuroMemo.Dal.Seed
{
    public class ScreeningDataSeeder : IDataSeeder<SzuroMemoDbContext, SzuroMemoSeedData>
    {
        public int SeedData(SzuroMemoDbContext context, Func<SzuroMemoSeedData> dataAccessor)
        {
            if (!context.Screening.Any())
            {
                context.AddRange(dataAccessor().Screenings.Where(s => !dataAccessor().Occasions.Select(o => o.Screening).Contains(s.Name)));
            }

            if (!context.Hospital.Any())
            {
                context.AddRange(dataAccessor().Hospitals.Where(s => !dataAccessor().Occasions.Select(o => o.Hospital).Contains(s.Name)));
            }

            if (!context.Occasion.Any())
            {
                context.Occasion.AddRange(dataAccessor().Occasions.Select(o => new Entities.Occasion
                {
                    StartTime = o.StartTime,
                    EndTime = o.EndTime,
                    Description = o.Description,
                    Screening = dataAccessor().Screenings.First(s => s.Name == o.Screening),
                    Hospital = dataAccessor().Hospitals.First(h => h.Name == o.Hospital)
                }));
            }

            
            return context.SaveChanges();
        }
    }
}
