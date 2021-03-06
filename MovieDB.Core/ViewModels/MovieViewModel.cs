﻿using MovieDB.Core.Api;
using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        private List<Movie> _nowPlaying;
        private List<Movie> _popular;
        private List<Movie> _topRated;
        private List<Movie> _similar;
        private Video _trailer;

        public MovieViewModel()
        {
            _nowPlaying = new List<Movie>();
            _popular = new List<Movie>();
            _topRated = new List<Movie>();
            _similar = new List<Movie>();
        }

        public List<Movie> NowPlaying
        {
            get { return _nowPlaying; }
        }

        public List<Movie> Popular
        {
            get { return _popular; }
        }

        public List<Movie> TopRated
        {
            get { return _topRated; }
        }

        public List<Movie> Similar
        {
            get { return _similar; }
        }

        public Movie SelectedMovie
        {
            get;
            set;
        }

        public Video SelectedMovieTrailer
        {
            get;
            set;
        }

        /// <summary>
        /// Get now playing movies
        /// </summary>
        /// <returns></returns>
        public async Task LoadNowPlaying()
        {
            IsBusy = true;
            try
            {
                //for now just show the first pages movies.
                var response = await _service.GetNowPlayingMovies();
                _nowPlaying = response?.Movies;
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get all popular movies
        /// </summary>
        /// <returns></returns>
        public async Task LoadPopular()
        {
            IsBusy = true;
            try
            {
                //for now just show the first page of popular movies.
                var response = await _service.GetPopularMovies();
                _popular = response?.Movies;
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get all top rated movies
        /// </summary>
        /// <returns></returns>
        public async Task LoadTopRated()
        {
            IsBusy = true;
            try
            {
                //for now just show the first page of top rated movies.
                var response = await _service.GetTopRatedMovies();
                _topRated = response?.Movies;
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get similar movies to the selected movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task LoadSimilar(int movieId)
        {
            IsBusy = true;
            try
            {
                var response = await _service.GetSimilarMovies(movieId);
                _similar = response?.Movies;
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get full details of a movie.
        /// Load similar movies to this one.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task GetMovie(int movieId)
        {
            IsBusy = true;
            try
            {
                SelectedMovie = await _service.GetMovie(movieId);
                await LoadSimilar(movieId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get the list of videos and save out the trailer
        /// Check the type & site for both trailer & youtube.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task GetVideos(int movieId)
        {
            IsBusy = true;
            try
            {
                var videoResponse = await _service.GetVideos(movieId);
                if (videoResponse != null && videoResponse.Videos != null)
                {
                    SelectedMovieTrailer = videoResponse.Videos.FirstOrDefault(v => v.Type == Constants.Trailer && v.Site == Constants.YouTube);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void Clear()
        {
            base.Clear();

            _popular.Clear();
            _topRated.Clear();
            _similar.Clear();
            _nowPlaying.Clear();

            SelectedMovie = null;
            SelectedMovieTrailer = null;
        }
    }
}
