using System;
using System.Linq;

namespace SzuroMemo.Dal.Seed
{
    public class ScreeningDataSeeder : IDataSeeder<SzuroMemoDbContext, SzuroMemoSeedData>
    {
        public int SeedData(SzuroMemoDbContext context, Func<SzuroMemoSeedData> dataAccessor)
        {
            var results = 0;
            if (!context.Screenings.Any())
            {
                context.AddRange(dataAccessor().Screenings);
                results += context.SaveChanges();
            }
            return results;
        }
    }
}
