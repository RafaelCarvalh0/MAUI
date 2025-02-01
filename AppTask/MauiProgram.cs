using AppTask.Database;
using AppTask.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace AppTask
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFontAwesomeIconFonts();
                })
                .RegisterAppServices()
                .UseUraniumUI()
                .UseUraniumUIMaterial();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            Services = app.Services; // Armazena o provedor de serviços
            return app;
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "apptask.db");
            mauiAppBuilder.Services.AddDbContext<AppTaskContext>(options =>
            options.UseSqlite($"Filename={databasePath}"));

            mauiAppBuilder.Services.AddSingleton<ITaskModelRepository, TaskModelRepository>();

            return mauiAppBuilder;
        }
    }
}
