using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Api
{
    [DataContract]
    public class QueryVideosResponse
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "results")]
        public List<Video> Videos { get; set; }
    }
}
