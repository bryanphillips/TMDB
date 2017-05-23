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
    public class QueryMoviesResponse
    {
        [DataMember(Name ="page")]
        public int Page { get; set; }
        [DataMember(Name = "results")]
        public List<Movie> Movies{ get; set; }
        [DataMember(Name = "dates")]
        public NowPlayingDates Dates { get; set; }
        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }
        [DataMember(Name = "total_results")]
        public int TotalResults { get; set; }
    }
}
