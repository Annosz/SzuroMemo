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
                var data = dataAccessor();

                var Screenings = data.Screenings.ToDictionary(s => s.Name, s => s);
                var Hospitals = data.Hospitals.ToDictionary(h => h.Name, h => h);
                //context.AddRange(dataAccessor().Screenings.Where(s => !dataAccessor().Occasions.Select(o => o.Screening).Contains(s.Name)));
                //context.AddRange(dataAccessor().Hospitals.Where(s => !dataAccessor().Occasions.Select(o => o.Hospital).Contains(s.Name)));

                context.Screening.AddRange(Screenings.Values);
                context.Hospital.AddRange(Hospitals.Values);
                context.Occasion.AddRange(dataAccessor().Occasions.Select(o => new Entities.Occasion
                {
                    StartTime = o.StartTime,
                    EndTime = o.EndTime,
                    Description = o.Description,
                    Screening = Screenings[o.Screening],
                    Hospital = Hospitals[o.Hospital]
                    //Screening = dataAccessor().Screenings.First(s => s.Name == o.Screening),
                    //Hospital = dataAccessor().Hospitals.First(h => h.Name == o.Hospital)
                }));
            }

            
            return context.SaveChanges();
        }
    }
}
