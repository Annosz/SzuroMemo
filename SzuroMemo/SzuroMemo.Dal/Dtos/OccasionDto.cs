using System;
using System.Collections.Generic;
using System.Text;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Dtos
{
    public class OccasionDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }
        public string Description { get; set; }

        public int ScreeningId { get; set; }
        public string Screening { get; set; }
        public bool ReferralNeeded { get; set; }

        public int HospitalId { get; set; }
        public string Hospital { get; set; }
        public Address Address { get; set; }
        public string PictureUrl { get; set; }

        public int RegistrationNum { get; set; }
    }
}
