﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SzuroMemo.Dal.Entities
{
    public class Address
    {
        public int ZipCode { get; set; }
        public string Settlement { get; set; }
        public string StreetAddress { get; set; }
    }
}
