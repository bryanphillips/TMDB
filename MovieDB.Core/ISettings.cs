using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core
{
    public interface ISettings
    {
        User User { get; set; }

        string Password { get; set; }

        /// <summary>
        /// List of Favorite Movies
        /// </summary>
        List<Favorite> Favorites { get; set; }

        void Save();
    }
}
