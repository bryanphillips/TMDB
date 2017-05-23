using MovieDB.Core.Api;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Tests
{
    [TestFixture]
    public class WebServiceTests
    {
        private WebService _service;

        [SetUp]
        public void SetUp()
        {
            TestSetup.Initialize();

            _service = new WebService { ApiKey = "071f34284387d9c1d0536c5e75d15443" };
        }

        [Test]
        public async Task GetMovie()
        {
            var movie = await _service.GetMovie("263115");

            Assert.IsNotNull(movie);
        }

        [Test]
        public async Task GetNowPlaying()
        {
            var response = await _service.GetNowPlayingMovies();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Movies);
            Assert.AreNotEqual(0, response.Movies.Count);
        }

        [Test]
        public async Task GetPopularMovies()
        {
            var response = await _service.GetPopularMovies();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Movies);
            Assert.AreNotEqual(0, response.Movies.Count);
        }

        [Test]
        public async Task GetSimilar()
        {
            var response = await _service.GetPopularMovies();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Movies);
            Assert.AreNotEqual(0, response.Movies.Count);

            var movie = response.Movies.FirstOrDefault();
            var similarResponse = await _service.GetSimilarMovies(movie.Id.ToString());

            Assert.IsNotNull(similarResponse);
            Assert.IsNotNull(similarResponse.Movies);
            Assert.AreNotEqual(0, similarResponse.Movies.Count);
        }

        [Test]
        public async Task GetVideos()
        {
            var response = await _service.GetPopularMovies();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Movies);
            Assert.AreNotEqual(0, response.Movies.Count);

            var movie = response.Movies.FirstOrDefault();
            var videoResponse = await _service.GetVideos(movie.Id.ToString());

            Assert.IsNotNull(videoResponse);
            Assert.IsNotNull(videoResponse.Videos);
            Assert.AreNotEqual(0, videoResponse.Videos.Count);
        }
    }
}
