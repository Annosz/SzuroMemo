using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public bool Male { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<LastScreening> LastScreenings { get; set; }
    }
}
