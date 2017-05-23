#define TESTMODE //use test mode so we don't slam the moviedb api. the fake webservice will have some stored values...comment this out to check if apikey & actual calls to moviedb api work.
using MovieDB.Core;
using MovieDB.Core.Api;
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
    public class MovieViewModelTests
    {
        private MovieViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            TestSetup.Initialize();
#if !TESTMODE
            ServiceContainer.Register<IWebService>(new WebService { ApiKey = "071f34284387d9c1d0536c5e75d15443" });
#endif
            _viewModel = ServiceContainer.Resolve<MovieViewModel>();
        }

        [Test]
        public async Task LoadNowPlayingMovies()
        {
            await _viewModel.LoadNowPlaying();
            Assert.AreNotEqual(0, _viewModel.NowPlaying.Count);
            _viewModel.SelectedMovie = _viewModel.NowPlaying.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);
        }

        [Test]
        public async Task LoadTopRated()
        {
            await _viewModel.LoadTopRated();
            Assert.AreNotEqual(0, _viewModel.TopRated.Count);
            _viewModel.SelectedMovie = _viewModel.TopRated.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);
        }

        [Test]
        public async Task LoadPopular()
        {
            await _viewModel.LoadPopular();
            Assert.AreNotEqual(0, _viewModel.Popular.Count);
            _viewModel.SelectedMovie = _viewModel.Popular.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);
        }

        [Test]
        public async Task LoadSimilar()
        {
            await _viewModel.LoadNowPlaying();
            Assert.AreNotEqual(0, _viewModel.NowPlaying.Count);
            _viewModel.SelectedMovie = _viewModel.NowPlaying.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);

            await _viewModel.LoadSimilar(_viewModel.SelectedMovie.Id);
            Assert.AreNotEqual(0, _viewModel.Similar.Count);
            var similarMovie = _viewModel.Similar.FirstOrDefault();
            Assert.IsNotNull(similarMovie);
        }

        [Test]
        public async Task GetMovie()
        {
            await _viewModel.LoadNowPlaying();
            Assert.AreNotEqual(0, _viewModel.NowPlaying.Count);
            _viewModel.SelectedMovie = _viewModel.NowPlaying.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);

            await _viewModel.LoadSimilar(_viewModel.SelectedMovie.Id);
            Assert.AreNotEqual(0, _viewModel.Similar.Count);
            var similarMovie = _viewModel.Similar.FirstOrDefault();
            Assert.IsNotNull(similarMovie);

            await _viewModel.GetMovie(similarMovie.Id);
            Assert.IsNotNull(_viewModel.SelectedMovie);
        }

        [Test]
        public async Task GetVideos()
        {
            await _viewModel.LoadNowPlaying();
            Assert.AreNotEqual(0, _viewModel.NowPlaying.Count);
            _viewModel.SelectedMovie = _viewModel.NowPlaying.FirstOrDefault();
            Assert.IsNotNull(_viewModel.SelectedMovie);
            await _viewModel.GetVideos(_viewModel.SelectedMovie.Id);
            Assert.IsNotNull(_viewModel.SelectedMovieTrailer);
        }
    }
}
