using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    /// <summary>
    /// Custom class for keeping track of a user's favorite movies.
    /// </summary>
    [DataContract]
    public class Favorite
    {
        [DataMember]
        public string MovieId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string PosterUrl { get; set; }
    }
}
