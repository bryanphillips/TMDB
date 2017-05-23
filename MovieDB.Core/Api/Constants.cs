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
        public const string YouTubeVideoUrl = "http://www.youtube.com/watch?v={0}";
        public const string ErrorText = "Something unexpected happened!";
        public const string YouTube = "YouTube";
        public const string Trailer = "Trailer";
    }
}
