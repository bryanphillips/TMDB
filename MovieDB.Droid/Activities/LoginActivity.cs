using Android.App;
using Android.OS;
using Android.Content.PM;
using MovieDB.Core.ViewModels;
using MovieDB.Core;
using Android.Widget;
using Android.Views;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDB.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class LoginActivity : BaseActivity
    {
        private readonly LoginViewModel _loginViewModel = ServiceContainer.Resolve<LoginViewModel>();
        private readonly MovieViewModel _movieViewModel = ServiceContainer.Resolve<MovieViewModel>();
        private EditText _username, _password;
        private Button _signIn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.login);

            _username = FindViewById<EditText>(Resource.Id.login_username);
            _password = FindViewById<EditText>(Resource.Id.login_password);
            _signIn = FindViewById<Button>(Resource.Id.login_signin);            

            //fake sign in to the app.
            _signIn.Click += async delegate
            {
                try
                {
                    ShowSpinner();

                    _loginViewModel.Username = _username.Text;
                    _loginViewModel.Password = _password.Text;

                    await _loginViewModel.Login();

                    var tasks = new List<Task>();
                    tasks.Add(_movieViewModel.LoadTopRated());
                    tasks.Add(_movieViewModel.LoadPopular());
                    tasks.Add(_movieViewModel.LoadNowPlaying());
                    foreach (var task in tasks)
                    {
                        await task;
                    }

                    var intent = new Intent(this, typeof(MoviesActivity));
                    intent.SetFlags(ActivityFlags.ClearTask | ActivityFlags.NewTask);
                    StartActivity(intent);
                }
                catch(Exception exc)
                {
                    OnError(exc);
                }
                finally
                {
                    HideSpinner();
                }
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            _username.Text = _loginViewModel.CurrentUser.UserName;
            _password.Text = _loginViewModel.CurrentUser.Password;
        }
    }
}

