using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SzuroMemo.Dal.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string BirthName { get; set; }
        public string MotherBirthName { get; set; }
        public Address Address { get; set; }
        public string Nationality { get; set; }
        public string TajNumber { get; set; }

        public GenderEnum? Gender { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public BloodTypeEnum? BloodType { get; set; }

        public bool FatherAsthma { get; set; }
        public bool FatherDiabetes { get; set; }
        public bool FatherAllergy { get; set; }
        public bool FatherHeartDisease { get; set; }
        public bool FatherTumour { get; set; }
        public bool FatherObese { get; set; }
        public bool MotherAsthma { get; set; }
        public bool MotherDiabetes { get; set; }
        public bool MotherAllergy { get; set; }
        public bool MotherHeartDisease { get; set; }
        public bool MotherTumour { get; set; }
        public bool MotherObese { get; set; }

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

        public enum BloodTypeEnum
        {
            [Display(Name = "O+")]
            OPositive,
            [Display(Name = "A+")]
            APositive,
            [Display(Name = "B+")]
            BPositive,
            [Display(Name = "AB+")]
            ABPositive,
            [Display(Name = "AB-")]
            ABNegative,
            [Display(Name = "A-")]
            ANegative,
            [Display(Name = "B-")]
            BNegative,
            [Display(Name = "O-")]
            ONegative
        }
    }
}
