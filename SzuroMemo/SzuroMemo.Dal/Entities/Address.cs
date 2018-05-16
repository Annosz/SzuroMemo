using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class Address
    {
        [Display(Name = "Irányítószám")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Egy valódi irányítószámot adjon meg.")]
        public int ZipCode { get; set; }

        [Display(Name = "Település")]
        [MaxLength(150, ErrorMessage = "Legfeljebb 150 karakter hosszú településnevet adjon meg.")]
        public string Settlement { get; set; }

        [Display(Name = "Utca, házszám")]
        [MaxLength(300, ErrorMessage = "Legfeljebb 300 karakter hosszú címet adjon meg.")]
        public string StreetAddress { get; set; }
    }
}
