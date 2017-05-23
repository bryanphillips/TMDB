using MovieDB.Core.Api;
using MovieDB.Core.Models;
using MovieDB.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Core
{
    /// <summary>
    /// Core class for initializing the app.
    /// </summary>
    public static class Startup
    {
        public static void Initialize(bool useFakeServices = false,
            Func<ILogger> logger = null,
            Func<ISettings> settings = null)
        {
            if (logger == null)
                logger = () => new DebugLogger();
            if (settings == null)
                settings = () => new FakeSettings();

            ServiceContainer.Register(logger);

            if (useFakeServices)
            {
                ServiceContainer.Register<IWebService>(() => new FakeWebService());
                ServiceContainer.Register<ISettings>(() => new FakeSettings());
            }
            else
            {
                ServiceContainer.Register<IWebService>(() => new WebService()
                {
                    ApiKey = "071f34284387d9c1d0536c5e75d15443",
                });
                ServiceContainer.Register(settings);
            }

            ServiceContainer.Register<LoginViewModel>();
            ServiceContainer.Register<MovieViewModel>();
            ServiceContainer.Register<FavoriteViewModel>();
        }
    }
}
