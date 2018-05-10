using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SzuroMemo.Dal.Entities.MedicalRecord;

namespace SzuroMemo.Dal.Dtos
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public GenderEnum? Gender { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Egy számot adjon meg.")]
        [Range(1, 750, ErrorMessage = "Egy 1 és 750 közötti számot adjon meg.")]
        public double? Height { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Egy számot adjon meg.")]
        [Range(1, 400, ErrorMessage = "Egy 1 és 400 közötti számot adjon meg.")]
        public double? Weight { get; set; }
    }
}
