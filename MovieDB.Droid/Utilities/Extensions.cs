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
using MovieDB.Core.Api;
using MovieDB.Core.Models;

namespace MovieDB.Droid.Utilities
{
    public static class Extensions
    {
        public static void ShowError(this Context context, Exception exc)
        {
            string message;
            string title = Constants.ErrorText;

#if DEBUG
            message = exc.Message;
#else
            if (exc is HttpRequestException)
            {
                message = "Check your internet connection and try again later.";
            }
            else if (exc is Java.Net.UnknownHostException)
            {
                title = "Sorry!";
                message = "Please reconnect to the internet to continue using the app.";
            }
            else
            {
                message = exc.Message;
            }
#endif

            try
            {
                new AlertDialog.Builder(context)
                    .SetCancelable(true)
                    .SetTitle(title)
                    .SetMessage(message)
                    .SetPositiveButton("Ok", (sender, e) => { })
                    .Show();
            }
            catch { }
        }

        public static void DisplayError(this Context context, Exception exc, string message)
        {
            try
            {
                string title = Constants.ErrorText;
                if (exc is Java.Net.UnknownHostException)
                {
                    title = "Sorry!";
                    message = "Please reconnect to the internet to continue using the app.";
                }

                new AlertDialog.Builder(context)
                    .SetCancelable(true)
                    .SetTitle(title)
                    .SetMessage(message)
                    .SetPositiveButton("Ok", (sender, e) => { })
                    .Show();
            }
            catch { }
        }

        public static string ToPosterUrl(this Movie movie, PosterSize size)
        {
            string imageSize = "Original";
            switch (size)
            {
                case PosterSize.W92:
                    imageSize = "w92";
                    break;
                case PosterSize.W154:
                    imageSize = "w154";
                    break;
                case PosterSize.W342:
                    imageSize = "w342";
                    break;
                case PosterSize.W500:
                    imageSize = "w500";
                    break;
                case PosterSize.W780:
                    imageSize = "w780";
                    break;
                default:
                    break;
            }

            return string.Format(Constants.ImageUrl, imageSize, movie.PosterUrl);
        }

        public static string ToBackdropUrl(this Movie movie, BackdropSize size)
        {
            string imageSize = "Original";
            switch (size)
            {
                case BackdropSize.W300:
                    imageSize = "w300";
                    break;
                case BackdropSize.W780:
                    imageSize = "w780";
                    break;
                case BackdropSize.W1280:
                    imageSize = "w1280";
                    break;
                default:
                    break;
            }

            return string.Format(Constants.ImageUrl, imageSize, movie.BackdropUrl);
        }
    }
}