using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// List of Favorite Movies
        /// </summary>
        [DataMember]
        public List<Favorite> Favorites { get; set; }
    }
}
