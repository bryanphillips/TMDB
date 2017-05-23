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
using Android.Content.PM;
using Android.Support.V7.Widget;
using MovieDB.Droid.Adapters;

namespace MovieDB.Droid
{
    [Activity(LaunchMode = LaunchMode.SingleTop)]
    public class MoviesActivity : Activity
    {
        private RecyclerView _movieView;
        private LinearLayoutManager _layoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.movies);

            _movieView = FindViewById<RecyclerView>(Resource.Id.movies_recyclerView);
            _layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            _movieView.SetLayoutManager(_layoutManager);
            _movieView.HasFixedSize = true;

            var adapter = new MoviesAdapter(this);
            _movieView.SetAdapter(adapter);
        }
    }
}