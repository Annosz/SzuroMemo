using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Dtos
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ReferralNeeded { get; set; }
        public string Description { get; set; }

        public int OccasionNum { get; set; }
    }
}
