using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class Video
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
        [DataMember(Name = "iso_639_1")]
        public string LanguageISO { get; set; }
        [DataMember(Name = "iso_3166_1")]
        public string CountryISO { get; set; }
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "site")]
        public string Site { get; set; }
        [DataMember(Name = "size")]
        public int Size { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
