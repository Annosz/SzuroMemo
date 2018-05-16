using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Dtos
{
    public class OccasionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Adjon meg egy időpontot.")]
        [Display(Name = "Kezdete")]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Adjon meg egy időpontot.")]
        [Display(Name = "Vége")]
        [DateGreaterThan("StartTime")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Részletes leírás")]
        [DataType(DataType.MultilineText)]
        [MaxLength(3000, ErrorMessage = "Legfeljebb 3000 karakter hosszú leírást adjon meg.")]
        public string Description { get; set; }

        [Display(Name = "Szűrés")]
        [Required(ErrorMessage = "Adjon meg egy szűréstípust.")]
        public int ScreeningId { get; set; }
        public string Screening { get; set; }
        [Display(Name = "Beutaló szükséges")]
        public bool ReferralNeeded { get; set; }

        [Display(Name = "Kórház")]
        [Required(ErrorMessage = "Adjon meg egy kórházat.")]
        public int HospitalId { get; set; }
        public string Hospital { get; set; }
        public Address Address { get; set; }
        public string PictureUrl { get; set; }

        public int RegistrationNum { get; set; }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime laterDate = (DateTime)value;

            DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);

            if (laterDate > earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A befejezés korábban van, mint a kezdés.");
            }
        }
    }
}
