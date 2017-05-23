using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.ViewModels
{
    public class FavoriteViewModel : ViewModelBase
    {
        private List<Favorite> _favorites;

        public FavoriteViewModel()
        {
            _favorites = _settings.User.Favorites ?? new List<Favorite>();
        }

        public List<Favorite> Favorites
        {
            get { return _favorites; }
        }

        public void Add(Movie movie)
        {
            _favorites.Add(new Favorite
            {
                MovieId = movie.Id.ToString(),
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
            });
        }

        public void Remove(string movieId)
        {
            var favorite = _favorites.FirstOrDefault(f => f.MovieId == movieId);
            if (favorite != null)
                _favorites.Remove(favorite);
        }

        public bool Exists(string movieId)
        {
            return _favorites.FirstOrDefault(f => f.MovieId == movieId) != null;
        }
    }
}
