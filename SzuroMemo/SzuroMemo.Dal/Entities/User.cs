using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
