using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Specifications
{
    public class OccasionSpecification
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string Screening { get; set; }
        public int? ScreeningId { get; set; }
        public string Hospital { get; set; }
        public int? HospitalId { get; set; }
        public string Settlement { get; set; }
        public DateTime? MinStart { get; set; }
        public DateTime? MaxEnd { get; set; }
        public bool? NotRegistered { get; set; }
        public bool? Actual { get; set; }

        public ScreeningOrder Order { get; set; }
        public enum ScreeningOrder
        {
            StartAscending,
            HospitalAscending,
            HospitalDescending,
            ScreeningAscending,
            ScreeningDescending,
            RegistrationNumAscending,
            RegistrationNumDescending,
            SettlementAscending,
            SettlementDescending
        }
    }
}
