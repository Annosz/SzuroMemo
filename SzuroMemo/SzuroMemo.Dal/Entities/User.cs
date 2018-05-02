using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
        public int MedicalRecordId { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
