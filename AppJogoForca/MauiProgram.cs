using AppJogoForca.Repositories;
using Microsoft.Extensions.Logging;

namespace AppJogoForca
{
    public static class MauiProgram
    {
        private static MauiApp _mauiApp;
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IWordRepository, WordRepository>();

            _mauiApp = builder.Build();
            return _mauiApp;
        }

        public static IServiceProvider Services => _mauiApp.Services;
    }
}
