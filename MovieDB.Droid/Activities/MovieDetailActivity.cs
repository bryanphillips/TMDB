using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MovieDB.Core.ViewModels;
using MovieDB.Core;
using MovieDB.Droid.Adapters;
using MovieDB.Droid.Utilities;
using Square.Picasso;

namespace MovieDB.Droid
{
    [Activity]
    public class MovieDetailActivity : BaseActivity
    {
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();
        private TextView _title, _overview, _releaseDate, _voteTotal;
        private RatingBar _rating;
        private ImageView _moviePoster;
        private Button _playVideo, _addtoFavorites;
        private GridView _similarMovies;
        private ScrollView _scrollView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.moviedetail);

            _title = FindViewById<TextView>(Resource.Id.moviedetail_title);
            _overview = FindViewById<TextView>(Resource.Id.moviedetail_overview);
            _releaseDate = FindViewById<TextView>(Resource.Id.moviedetail_releasedate);
            _voteTotal = FindViewById<TextView>(Resource.Id.moviedetail_totalvotes);
            _rating = FindViewById<RatingBar>(Resource.Id.moviedetail_rating);
            _moviePoster = FindViewById<ImageView>(Resource.Id.moviedetail_movieimage);
            _playVideo = FindViewById<Button>(Resource.Id.moviedetail_playvideo);
            _addtoFavorites = FindViewById<Button>(Resource.Id.moviedetail_addtofavorites);
            _similarMovies = FindViewById<GridView>(Resource.Id.moviedetail_similarmoviesgrid);
            _scrollView = FindViewById<ScrollView>(Resource.Id.moviedetail_scrollview);

            _title.Text = _movieViewModel.SelectedMovie.Title;
            _overview.Text = _movieViewModel.SelectedMovie.Overview;
            _releaseDate.Text = $"Release Date: {_movieViewModel.SelectedMovie.ReleaseDate.ToShortDateString()}";
            _voteTotal.Text = $"from {_movieViewModel.SelectedMovie.VoteCount} votes";
            _rating.Rating = _movieViewModel.SelectedMovie.VoteAverage / 2f;

            string url = _movieViewModel.SelectedMovie.ToPosterUrl(PosterSize.W780);
            Picasso.With(this).Load(url).Into(_moviePoster);

            _similarMovies.Adapter = new SimilarMoviesAdapter(this);
            _similarMovies.ItemClick += SimilarMovieSelected;
        }

        protected override void OnResume()
        {
            base.OnResume();            
        }

        private async void SimilarMovieSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            var movie = _movieViewModel.Similar.ElementAtOrDefault(e.Position);
            if (movie != null)
            {
                await _movieViewModel.GetMovie(movie.Id.ToString());
                StartActivity(typeof(MovieDetailActivity));
            }
        }
    }
}