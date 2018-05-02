using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PictureUrl { get; set; }

        public ICollection<Occasion> Occasions { get; set; }
    }
}
