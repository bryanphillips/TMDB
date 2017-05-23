using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using MovieDB.Core.Models;
using MovieDB.Core.ViewModels;
using MovieDB.Core;
using MovieDB.Droid.Utilities;
using Square.Picasso;
using System;

namespace MovieDB.Droid.Adapters
{
    public class MovieItemAdapter : RecyclerView.Adapter
    {
        private Context _context;
        private List<Movie> _movies;
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();

        public MovieItemAdapter(Context context, List<Movie> movies)
        {
            _context = context;
            _movies = movies;            
        }

        public override int ItemCount => _movies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as MovieItemViewHolder;
            var item = _movies.ElementAtOrDefault(position);
            if (item != null)
            {
                string url = item.ToPosterUrl(PosterSize.W342);
                Picasso.With(_context).Load(url).Into(viewHolder.ImageView);
                viewHolder.ItemView.Tag = item.Id;
            }          
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(_context).Inflate(Resource.Layout.movieitem, parent, false);
            return new MovieItemViewHolder(view, _context);
        }
    }

    public class MovieItemViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        private readonly ILogger _logger = ServiceContainer.Resolve<ILogger>();
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();
        private readonly FavoriteViewModel _favoriteViewModel = ServiceContainer.Resolve<FavoriteViewModel>();
        private ImageView _imageView;
        private View _rootView;
        private Context _context;

        public MovieItemViewHolder(View itemView, Context context) : base(itemView)
        {
            _context = context;
            _rootView = itemView;
            _imageView = itemView.FindViewById<ImageView>(Resource.Id.movieitem_image);
            ItemView.SetOnClickListener(this);
        }

        public ImageView ImageView
        {
            get { return _imageView; }
        }

        public async void OnClick(View v)
        {
            //check the tag to see what movie it is. then navigate to next activity to show the movie.
            if(_rootView.Tag == v.Tag)
            {
                _logger.Log("MovieItemViewHolder", $"Movie ID = {_rootView.Tag}");
                await _movieViewModel.GetMovie(_rootView.Tag.ToString());
                await _movieViewModel.GetVideos(_rootView.Tag.ToString());
                _favoriteViewModel.LoadFavorites();
                _context.StartActivity(typeof(MovieDetailActivity));
            }
        }
    }
}