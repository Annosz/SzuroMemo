using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Occasion Occasion { get; set; }
        public int OccasionId { get; set; }
    }
}
