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
    public class FavoriteViewTests
    {
        private FavoriteViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            TestSetup.Initialize();

            var settings = ServiceContainer.Resolve<ISettings>();
            settings.User = new Core.Models.User
            {
                UserName = "Chuck",
                Password = "Norris",
            };
            settings.Favorites = new List<Favorite>();
            _viewModel = new FavoriteViewModel();
        }

        [Test]
        public void AddFavorite()
        {
            var settings = ServiceContainer.Resolve<ISettings>();
            _viewModel.LoadFavorites();

            Assert.IsNotNull(settings.Favorites);
            Assert.AreEqual(0, settings.Favorites.Count);
            Assert.AreEqual(0, _viewModel.Favorites.Count);

            _viewModel.Add(
                new Movie
                {
                    Id = 283995,
                    Title = "Guardians of the Galaxy Vol. 2",
                    PosterUrl = "/y4MBh0EjBlMuOzv9axM4qJlmhzz.jpg",
                });

            Assert.AreEqual(1, settings.Favorites.Count);
            Assert.AreEqual(1, _viewModel.Favorites.Count);
        }

        [Test]
        public void RemoveFavorite()
        {
            var settings = ServiceContainer.Resolve<ISettings>();
            _viewModel.LoadFavorites();

            _viewModel.Add(
                new Movie
                {
                    Id = 283995,
                    Title = "Guardians of the Galaxy Vol. 2",
                    PosterUrl = "/y4MBh0EjBlMuOzv9axM4qJlmhzz.jpg",
                });

            Assert.AreEqual(1, settings.Favorites.Count);
            Assert.AreEqual(1, _viewModel.Favorites.Count);

            _viewModel.Remove("283995");

            Assert.AreEqual(0, settings.Favorites.Count);
            Assert.AreEqual(0, _viewModel.Favorites.Count);
        }

        [Test]
        public void IsFavorited()
        {
            var settings = ServiceContainer.Resolve<ISettings>();
            _viewModel.LoadFavorites();

            Assert.IsNotNull(settings.Favorites);
            Assert.AreEqual(0, settings.Favorites.Count);
            Assert.AreEqual(0, _viewModel.Favorites.Count);

            _viewModel.Add(
                new Movie
                {
                    Id = 283995,
                    Title = "Guardians of the Galaxy Vol. 2",
                    PosterUrl = "/y4MBh0EjBlMuOzv9axM4qJlmhzz.jpg",
                });

            Assert.AreEqual(1, settings.Favorites.Count);
            Assert.AreEqual(1, _viewModel.Favorites.Count);

            Assert.IsTrue(_viewModel.IsFavorite("283995"));
        }
    }
}
