using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Seed
{
    public class SzuroMemoSeedData
    {
        public Screening[] Screenings { get; set; } =
        {
            new Screening { Name = "Nőgyógyászati rákszűrés", ReferralNeeded = false, Description = "Itt megnézi a lányok punciját"}
        };
    }
}
