using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class MovieCollection
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "poster_path")]
        public string PosterImageUrl { get; set; }
        [DataMember(Name = "backdrop_path")]
        public string BackdropImageUrl { get; set; }
    }
}
