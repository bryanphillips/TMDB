using MovieDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; Validate(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; Validate(); }
        }

        public User CurrentUser
        {
            get;
            internal set;
        }

        public LoginViewModel()
        {
            CurrentUser = _settings.User ?? new User();
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <returns></returns>
        public async Task Login()
        {
            if (!IsValid)
                throw new Exception(Error);

            IsBusy = true;
            try
            {
                CurrentUser = await _service.Login(_username, _password);
                //if different account
                if (_settings.User != null && _settings.User.UserName != CurrentUser.UserName)
                {
                    _settings.User.Favorites?.Clear();
                }

                //if real app, the password would be md5 hash or some other kind of encryption to store locally, for this purpse just store it as it is typed.
                CurrentUser.Password = Password;
                CurrentUser.Favorites = _settings.User?.Favorites;
                _settings.User = CurrentUser;
                _settings.Save();
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void Validate()
        {
            ValidateProperty(() => string.IsNullOrEmpty(_username), "Please enter a username.");
            ValidateProperty(() => string.IsNullOrEmpty(_password), "Please enter a password.");
            base.Validate();
        }

        public override void Clear()
        {
            Username =
                Password = null;
        }
    }
}
