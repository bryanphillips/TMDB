using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class NowPlayingDates
    {
        [DataMember(Name = "maximum")]
        public DateTime MaxDate { get; set; }
        [DataMember(Name = "minimum")]
        public DateTime MinDate { get; set; }
    }
}
