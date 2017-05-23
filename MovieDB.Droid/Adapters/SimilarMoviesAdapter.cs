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
using Square.Picasso;
using MovieDB.Droid.Utilities;

namespace MovieDB.Droid.Adapters
{
    public class SimilarMoviesAdapter : BaseAdapter
    {
        private Context _context;
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();

        public SimilarMoviesAdapter(Context context)
        {
            _context = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.FromContext(_context).Inflate(Resource.Layout.similarmovieitem, null);
            }

            var image = convertView.FindViewById<ImageView>(Resource.Id.similarmovieitem_image);
            var movie = _movieViewModel.Similar.ElementAtOrDefault(position);
            if (movie != null)
            {
                string url = movie.ToPosterUrl(PosterSize.W342);
                Picasso.With(_context).Load(url).Into(image);
            }

            return convertView;
        }

        public override int Count
        {
            get
            {
                if (_movieViewModel.Similar != null)
                    return _movieViewModel.Similar.Count;
                return 0;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
