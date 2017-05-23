using MovieDB.Core;
using MovieDB.Core.Models;
using MovieDB.Core.ViewModels;

namespace MovieDB.Tests
{
    public static class TestSetup
    {
        public static void Initialize()
        {
            ServiceContainer.Register<ILogger>(() => new DebugLogger());
            ServiceContainer.Register<ISettings>(() => new FakeSettings());
            ServiceContainer.Register<IWebService>(() => new FakeWebService { Sleep = 0 });
            ServiceContainer.Register(() => new LoginViewModel());
            ServiceContainer.Register(() => new MovieViewModel());
            ServiceContainer.Register(() => new FavoriteViewModel());
        }
    }
}
