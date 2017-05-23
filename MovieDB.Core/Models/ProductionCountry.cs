﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class ProductionCountry
    {
        [DataMember(Name = "iso_3166_1")]
        public string CountryCode { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
