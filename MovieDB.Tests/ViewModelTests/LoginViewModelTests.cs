using MovieDB.Core;
using MovieDB.Core.Models;
using MovieDB.Core.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Tests.ViewModelTests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        private LoginViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            TestSetup.Initialize();
            _viewModel = ServiceContainer.Resolve<LoginViewModel>();
        }

        [Test]
        public async Task LoginNewUser()
        {
            string userName = "username";
            string password = "password";
            _viewModel.Username = userName;
            _viewModel.Password = password;

            await _viewModel.Login();

            Assert.IsNotNull(_viewModel.CurrentUser);
            Assert.AreEqual(userName, _viewModel.CurrentUser.UserName);
            Assert.AreEqual(password, _viewModel.CurrentUser.Password);
        }

        [Test]
        public async Task LoginDifferentUser()
        {
            var settings = ServiceContainer.Resolve<ISettings>();
            settings.User = new Core.Models.User
            {
                UserName = "Chuck",
                Password = "Norris",
            };

            string userName = "username";
            string password = "password";
            _viewModel.Username = userName;
            _viewModel.Password = password;

            await _viewModel.Login();

            Assert.IsNotNull(_viewModel.CurrentUser);
            Assert.AreEqual(userName, _viewModel.CurrentUser.UserName);
            Assert.AreEqual(password, _viewModel.CurrentUser.Password);
        }

        [Test]
        public async Task LoginExistingUser()
        {
            var settings = ServiceContainer.Resolve<ISettings>();
            settings.User = new Core.Models.User
            {
                UserName = "username",
                Password = "password",
                Favorites = new List<Favorite>
                {
                    new Favorite
                    {
                        MovieId = "1234",
                        PosterUrl = "www.google.com",
                        Title = "Google: The Movie",
                    },
                },
            };

            string userName = "username";
            string password = "password";
            _viewModel.Username = userName;
            _viewModel.Password = password;

            await _viewModel.Login();

            Assert.IsNotNull(_viewModel.CurrentUser);
            Assert.AreEqual(userName, _viewModel.CurrentUser.UserName);
            Assert.AreEqual(password, _viewModel.CurrentUser.Password);
            Assert.IsNotNull(_viewModel.CurrentUser.Favorites);
            Assert.AreNotEqual(0, _viewModel.CurrentUser.Favorites.Count);
        }
    }
}
