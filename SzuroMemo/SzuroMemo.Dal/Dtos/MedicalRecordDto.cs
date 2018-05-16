using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SzuroMemo.Dal.Entities;
using static SzuroMemo.Dal.Entities.MedicalRecord;

namespace SzuroMemo.Dal.Dtos
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }

        [Display(Name = "Teljes név")]
        [MaxLength(150, ErrorMessage = "Legfeljebb 150 karakter hosszú nevet adjon meg.")]
        public string FullName { get; set; }

        [Display(Name = "Születési név")]
        [MaxLength(150, ErrorMessage = "Legfeljebb 150 karakter hosszú nevet adjon meg.")]
        public string BirthName { get; set; }

        [Display(Name = "Édesanyja név")]
        [MaxLength(150, ErrorMessage = "Legfeljebb 150 karakter hosszú nevet adjon meg.")]
        public string MotherBirthName { get; set; }

        [Display(Name = "Állandó lakcím")]
        public Address Address { get; set; }

        [Display(Name = "Nemzetiség")]
        [MaxLength(50, ErrorMessage = "Legfeljebb 50 karakter hosszú nemzetiséget adjon meg.")]
        public string Nationality { get; set; }

        [Display(Name = "TAJ kártya száma")]
        [RegularExpression("[0-9]{3}[ ]?[0-9]{3}[ ][0-9]{3}", ErrorMessage = "Egy valódi TAJ számot adjon meg.")]
        public string TajNumber { get; set; }



        [Display(Name = "Biológiai nem")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "Magasság (cm)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Egy számot adjon meg.")]
        [Range(1, 750, ErrorMessage = "Egy 1 és 750 közötti számot adjon meg.")]
        public double? Height { get; set; }

        [Display(Name = "Tömeg (kg)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Egy számot adjon meg.")]
        [Range(1, 400, ErrorMessage = "Egy 1 és 400 közötti számot adjon meg.")]
        public double? Weight { get; set; }

        [Display(Name = "Vércsoport")]
        public BloodTypeEnum? BloodType { get; set; }


        [Display(Name = "Asztma")]
        public bool FatherAsthma { get; set; }

        [Display(Name = "Cukorbetegség")]
        public bool FatherDiabetes { get; set; }

        [Display(Name = "Allergia")]
        public bool FatherAllergy { get; set; }

        [Display(Name = "Szívbetegség")]
        public bool FatherHeartDisease { get; set; }

        [Display(Name = "Daganat")]
        public bool FatherTumour { get; set; }

        [Display(Name = "Elhízás")]
        public bool FatherObese { get; set; }

        [Display(Name = "Asztma")]
        public bool MotherAsthma { get; set; }

        [Display(Name = "Cukorbetegség")]
        public bool MotherDiabetes { get; set; }

        [Display(Name = "Allergia")]
        public bool MotherAllergy { get; set; }

        [Display(Name = "Szívbetegség")]
        public bool MotherHeartDisease { get; set; }

        [Display(Name = "Daganat")]
        public bool MotherTumour { get; set; }

        [Display(Name = "Elhízás")]
        public bool MotherObese { get; set; }

        public Dictionary<string, DateTime?> LastScreenings { get; set; } = new Dictionary<string, DateTime?>();
    }
}
