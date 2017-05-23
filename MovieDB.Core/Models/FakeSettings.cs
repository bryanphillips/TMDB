using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Models
{
    /// <summary>
    /// Basically doesn't do anything
    /// </summary>
    public class FakeSettings : ISettings
    {
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: might secure this better later on
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        public void Save()
        {
        }
    }
}
