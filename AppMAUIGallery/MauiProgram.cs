using Microsoft.Extensions.Logging;
using AppMAUIGallery;
using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views;

namespace AppMAUIGallery
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
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Registro de serviços
            builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

            // Criação da aplicação MAUI
            _mauiApp = builder.Build();
            return _mauiApp;
        }

        // Propriedade para acessar os serviços
        public static IServiceProvider Services => _mauiApp.Services;
    }
}
