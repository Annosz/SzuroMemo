using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class LastScreening
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int NextRecommended { get; set; }

        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
        public int MedicalRecordId { get; set; }
    }
}
