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
using Android.Support.V7.Widget;
using MovieDB.Core.ViewModels;
using MovieDB.Core;
using MovieDB.Core.Models;

namespace MovieDB.Droid.Adapters
{
    public class MoviesAdapter : RecyclerView.Adapter
    {
        private Context _context;
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();
        private List<List<Movie>> _movies = new List<List<Movie>>();

        public MoviesAdapter(Context context)
        {
            _context = context;

            _movies.Add(_movieViewModel.TopRated);
            _movies.Add(_movieViewModel.Popular);
            _movies.Add(_movieViewModel.NowPlaying);
        }

        public override int ItemCount => _movies.Count; //Now Playing, Popular, Top Rated

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as MovieListViewHolder;
            var movieList = _movies.ElementAt(position);
            var layoutManager = new LinearLayoutManager(_context, LinearLayoutManager.Horizontal, false);
            viewHolder.RecyclerView.SetLayoutManager(layoutManager);
            viewHolder.RecyclerView.HasFixedSize = true;

            SetupAdapter(viewHolder, position);

            viewHolder.RecyclerView.AddOnScrollListener(new ScrollListener(viewHolder.RecyclerView));            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(_context).Inflate(Resource.Layout.movierow, parent, false);

            return new MovieListViewHolder(view);
        }

        /// <summary>
        /// Setup the adapter for each of the recyclerviews & setup the title for for each of the recyclerviews.
        /// </summary>
        /// <param name="viewHolder"></param>
        /// <param name="position"></param>
        private void SetupAdapter(MovieListViewHolder viewHolder, int position)
        {
            MovieItemAdapter adapter = null;
            switch ((MovieListType)position)
            {
                case MovieListType.TopRated:
                    adapter = new MovieItemAdapter(_context, _movieViewModel.TopRated);
                    viewHolder.Title.Text = _context.Resources.GetString(Resource.String.TopRated);
                    break;
                case MovieListType.Popular:
                    adapter = new MovieItemAdapter(_context, _movieViewModel.Popular);
                    viewHolder.Title.Text = _context.Resources.GetString(Resource.String.Popular);
                    break;
                default:
                    adapter = new MovieItemAdapter(_context, _movieViewModel.NowPlaying);
                    viewHolder.Title.Text = _context.Resources.GetString(Resource.String.NowPlaying);
                    break;
            }            
            viewHolder.RecyclerView.SetAdapter(adapter);
        }
    }

    public class MovieListViewHolder : RecyclerView.ViewHolder
    {
        private TextView _textView;
        private RecyclerView _recyclerView;
        private View _rootView;

        public MovieListViewHolder(View itemView) : base(itemView)
        {
            _rootView = itemView;
            _textView = itemView.FindViewById<TextView>(Resource.Id.movierow_title);
            _recyclerView = itemView.FindViewById<RecyclerView>(Resource.Id.movierow_item);
        }

        public TextView Title
        {
            get { return _textView; }
        }

        public RecyclerView RecyclerView
        {
            get { return _recyclerView; }
        }
    }

    public class ScrollListener : RecyclerView.OnScrollListener
    {
        private readonly ILogger _logger = ServiceContainer.Resolve<ILogger>();
        private RecyclerView _parent;
        public ScrollListener(RecyclerView parent)
        {
            _parent = parent;
        }

        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            switch (newState)
            {
                case RecyclerView.ScrollStateIdle:
                    {
                        //float targetBottomPosition1 = _parent.GetX();
                        //float targetBottomPosition2 = _parent.GetX() + _parent.Width;

                        //Log.Info(TAG, "targetBottomPosition1 = " + targetBottomPosition1);
                        //Log.Info(TAG, "targetBottomPosition2 = " + targetBottomPosition2);

                        //View v1 = _parent.FindChildViewUnder(targetBottomPosition1, 0);
                        //View v2 = _parent.FindChildViewUnder(targetBottomPosition2, 0);

                        //float x1 = targetBottomPosition1;
                        //if (v1 != null)
                        //{
                        //    x1 = v1.GetX();
                        //}

                        //float x2 = targetBottomPosition2;
                        //if (v2 != null)
                        //{
                        //    x2 = v2.GetX();
                        //}


                        //Log.Info(TAG, "x1 = " + x1);
                        //Log.Info(TAG, "x2 = " + x2);

                        //float dx1 = Math.Abs(_parent.GetX() - x1);
                        //float dx2 = Math.Abs(_parent.GetX() + _parent.Width - x2);

                        //Log.Info(TAG, "dx1 = " + dx1);
                        //Log.Info(TAG, "dx2 = " + dx2);

                        //float visiblePortionOfItem1 = 0;
                        //float visiblePortionOfItem2 = 0;

                        //if (x1 < 0 && v1 != null)
                        //{
                        //    visiblePortionOfItem1 = v1.Width - dx1;
                        //}

                        //if (v2 != null)
                        //{
                        //    visiblePortionOfItem2 = v2.Width - dx2;
                        //}

                        //Log.Info(TAG, "visiblePortionOfItem1 = " + visiblePortionOfItem1);
                        //Log.Info(TAG, "visiblePortionOfItem2 = " + visiblePortionOfItem2);

                        //int position = 0;
                        //if (visiblePortionOfItem1 >= visiblePortionOfItem2)
                        //{
                        //    position = _parent.GetChildPosition(_parent.FindChildViewUnder(targetBottomPosition1, 0));
                        //}
                        //else
                        //{

                        //    position = _parent.GetChildPosition(_parent.FindChildViewUnder(targetBottomPosition2, 0));
                        //}
                        //_parent.ScrollToPosition(position);
                        //snapping looks off, don't use for time being.
                    }
                    break;
                case RecyclerView.ScrollStateDragging:
                    break;
                case RecyclerView.ScrollStateSettling:
                    break;
                default:
                    break;
            }
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            //_logger.Log("Movies RecyclerView", "X = " + dx + " and Y = " + dy);
        }
    }
}