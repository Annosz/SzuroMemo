using System;
using System.Linq;

namespace SzuroMemo.Dal.Seed
{
    public class ScreeningDataSeeder : IDataSeeder<SzuroMemoDbContext, SzuroMemoSeedData>
    {
        public int SeedData(SzuroMemoDbContext context, Func<SzuroMemoSeedData> dataAccessor)
        {
            if (!context.Screenings.Any())
            {
                context.AddRange(dataAccessor().Screenings);
            }

            if (!context.Hospital.Any())
            {
                context.AddRange(dataAccessor().Hospitals);
            }

            if (!context.User.Any())
            {
                context.AddRange(dataAccessor().Users);
            }

            if (!context.MedicalRecord.Any())
            {
                context.AddRange(dataAccessor().MedicalRecords);
                for (int i = 0; i < context.MedicalRecord.Count(); i++)
                {
                    context.MedicalRecord.ElementAt(i).User = context.User.ElementAt(i);
                    context.User.ElementAt(i).MedicalRecord = context.MedicalRecord.ElementAt(i);
                }
            }

            if (!context.LastScreening.Any())
            {
                context.AddRange(dataAccessor().LastScreenings);
            }

            
            return context.SaveChanges();
        }
    }
}
