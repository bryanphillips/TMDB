using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.Api
{
    public static class Constants
    {
        public const string BaseUrl = "http://api.themoviedb.org/3/{0}?api_key={1}";
        public const string ImageUrl = "https://image.tmdb.org/t/p/{0}{1}";
        public const string ErrorText = "Something unexpected happened!";
    }
}
