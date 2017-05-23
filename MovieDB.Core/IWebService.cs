using MovieDB.Core.Api;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core
{
    public interface IWebService
    {
        Task<User> Login(string userName, string password);
        Task<Movie> GetMovie(int movieId);
        Task<QueryMoviesResponse> GetNowPlayingMovies();
        Task<QueryMoviesResponse> GetTopRatedMovies();
        Task<QueryMoviesResponse> GetPopularMovies();
        Task<QueryMoviesResponse> GetSimilarMovies(int movieId);
        Task<QueryVideosResponse> GetVideos(int movieId);
    }
}
