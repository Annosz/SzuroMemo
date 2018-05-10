using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SzuroMemo.Dal.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public GenderEnum? Gender { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<LastScreening> LastScreenings { get; set; }

        public enum GenderEnum
        {
            [Display(Name = "Férfi")]
            Male = 1,
            [Display(Name = "Nő")]
            Female = 2
        }
    }
}
