using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Dtos
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        
        public int UserId { get; set; }
        
        public int OccasionId { get; set; }
    }
}
