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
        private readonly FavoriteViewModel _favoriteViewModel = ServiceContainer.Resolve<FavoriteViewModel>();
        private TextView _title, _overview, _releaseDate, _voteTotal;
        private RatingBar _rating;
        private ImageView _moviePoster;
        private Button _playVideo, _addRemoveFavorite;
        private ExpandableGridView _similarMovies;
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
            _addRemoveFavorite = FindViewById<Button>(Resource.Id.moviedetail_addtofavorites);
            _similarMovies = FindViewById<ExpandableGridView>(Resource.Id.moviedetail_similarmoviesgrid);
            _scrollView = FindViewById<ScrollView>(Resource.Id.moviedetail_scrollview);

            _title.Text = _movieViewModel.SelectedMovie.Title;
            _overview.Text = _movieViewModel.SelectedMovie.Overview;
            _releaseDate.Text = $"Release Date: {_movieViewModel.SelectedMovie.ReleaseDate.ToShortDateString()}";
            _voteTotal.Text = $"(from {_movieViewModel.SelectedMovie.VoteCount} votes)";
            _rating.Rating = _movieViewModel.SelectedMovie.VoteAverage / 2f;

            string url = _movieViewModel.SelectedMovie.ToPosterUrl(PosterSize.W780);
            Picasso.With(this).Load(url).Into(_moviePoster);

            _similarMovies.IsExpanded = true;
            var gridAdapter = new SimilarMoviesAdapter(this);
            _similarMovies.Adapter = gridAdapter;
            gridAdapter.NotifyDataSetChanged();
            _similarMovies.ItemClick += SimilarMovieSelected;

            _playVideo.Click += (sender, e) =>
            {
                new AlertDialog.Builder(this)
                .SetTitle("Oops!")
                .SetMessage("It looks like this option is not implemented yet.")
                .SetPositiveButton("Ok", (@object, @eventargs) => { })
                .Show();
            };
            _addRemoveFavorite.Click += (sender, e) =>
            {
                string movieId = _movieViewModel.SelectedMovie.Id.ToString();
                if (_favoriteViewModel.IsFavorite(movieId))
                {
                    _favoriteViewModel.Remove(movieId);
                    _addRemoveFavorite.Text = Resources.GetString(Resource.String.SaveToFavorites);
                }
                else
                {
                    _favoriteViewModel.Add(_movieViewModel.SelectedMovie);
                    _addRemoveFavorite.Text = Resources.GetString(Resource.String.RemoveFavorites);
                }
            };
            _addRemoveFavorite.Text = _favoriteViewModel.IsFavorite(_movieViewModel.SelectedMovie.Id.ToString()) ? Resources.GetString(Resource.String.RemoveFavorites) : Resources.GetString(Resource.String.SaveToFavorites);
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