using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class Occasion
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }

        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
