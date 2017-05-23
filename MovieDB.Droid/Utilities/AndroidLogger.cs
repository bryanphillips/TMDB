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
using MovieDB.Core;

namespace MovieDB.Droid
{
    public class AndroidLogger : ILogger
    {
        private const string Tag = "MovieDB";
        private const int MaxLength = 2048;

        public void Log(string label, object value)
        {
            string message = label + ": " + value;
            if (message.Length > MaxLength)
                message = message.Substring(0, MaxLength);
            Android.Util.Log.Debug(Tag, message);
        }
    }
}