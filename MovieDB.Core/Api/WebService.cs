using MovieDB.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieDB.Core.Api
{
    public class WebService : IWebService
    {
        private readonly ILogger _logger = ServiceContainer.Resolve<ILogger>();
        private readonly HttpMessageHandler _handler;
        private readonly MediaTypeWithQualityHeaderValue _mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        public const int TimeOut = 30;

        public string BaseUrl { get; internal set; }
        
        public string ApiKey { get; set; }

        public WebService()
        {
            BaseUrl = Constants.BaseUrl;
            _handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            };
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient(_handler);
            client.DefaultRequestHeaders.Accept.Add(_mediaType);
            return client;
        }

        private Task<T> Deserialize<T>(Stream stream)
        {
            return Task.Factory.StartNew(() =>
            {
                using (stream)
                using (var reader = new StreamReader(stream))
#if DEBUG
                {
                    string text = reader.ReadToEnd();
                    _logger.Log("RECEIVED", text);
                    return JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                    });
                }
#else
                using (var jsonReader = new JsonTextReader(reader))
                {
                    return _serializer.Deserialize<T>(jsonReader);
                }
#endif
            });
        }

        private async Task<T> GetAsync<T>(string url)
        {
            url = string.Format(BaseUrl, url, ApiKey);
#if DEBUG
            _logger.Log("GET", url);
#endif

            var client = GetClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await Deserialize<T>(stream);
        }

        /// <summary>
        /// In a real application this would be sent to the server, this app will just return the user after a task delay to simulate a server call
        /// </summary>
        /// <param name="userName">usually email</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> Login(string userName, string password)
        {
            await Task.Delay(100);
            return new User { UserName = userName };
        }

        public async Task<Movie> GetMovie(string movieId)
        {
            return await GetAsync<Movie>("movie/" + movieId);
        }

        public async Task<QueryMoviesResponse> GetNowPlayingMovies()
        {
            return await GetAsync<QueryMoviesResponse>("movie/now_playing");
        }

        public async Task<QueryMoviesResponse> GetPopularMovies()
        {
            return await GetAsync<QueryMoviesResponse>("movie/popular");
        }

        public async Task<QueryMoviesResponse> GetSimilarMovies(string movieId)
        {
            return await GetAsync<QueryMoviesResponse>($"movie/{movieId}/similar");
        }

        public async Task<QueryMoviesResponse> GetTopRatedMovies()
        {
            return await GetAsync<QueryMoviesResponse>("movie/top_rated");
        }

        public async Task<QueryVideosResponse> GetVideos(string movieId)
        {
            return await GetAsync<QueryVideosResponse>($"movie/{movieId}/videos");
        }
    }
}
