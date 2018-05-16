using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SzuroMemo.Dal.Specifications
{
    public class OccasionSpecification
    {
        public int? PageNumber { get; set; }
        [DisplayName("Találatok száma egy oldalon")]
        public int? PageSize { get; set; }

        [DisplayName("Szűrővizsgálat")]
        public string Screening { get; set; }
        public int? ScreeningId { get; set; }
        [DisplayName("Kórház")]
        public string Hospital { get; set; }
        public int? HospitalId { get; set; }
        [DisplayName("Település")]
        public string Settlement { get; set; }
        [DisplayName("Legkorábbi kezdés")]
        public DateTime? MinStart { get; set; }
        [DisplayName("Legkésőbbi befejezés")]
        public DateTime? MaxEnd { get; set; }
        [DisplayName("Nem beutalóköteles")]
        public bool ReferralNotNeeded { get; set; } = false;
        [DisplayName("Leírással")]
        public bool HasDescription { get; set; } = false;
        public bool? Actual { get; set; }

        public ScreeningOrder Order { get; set; } = ScreeningOrder.StartAscending;
        public enum ScreeningOrder
        {
            [Display(Name = "Kezdés szerint növekvő")]
            StartAscending,
            [Display(Name = "Kórháznév szerint növekvő")]
            HospitalAscending,
            [Display(Name = "Kórháznév szerint csökkenő")]
            HospitalDescending,
            [Display(Name = "Szűrésnév szerint növekvő")]
            ScreeningAscending,
            [Display(Name = "Szűrésnév szerint csökkenő")]
            ScreeningDescending,
            [Display(Name = "Regisztrációk száma szerint növekvő")]
            RegistrationNumAscending,
            [Display(Name = "Regisztrációk száma szerint csökkenő")]
            RegistrationNumDescending,
            [Display(Name = "Település neve szerint növekvő")]
            SettlementAscending,
            [Display(Name = "Telepölés neve szerint csökkenő")]
            SettlementDescending
        }
    }
}
