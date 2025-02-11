using AppTask.Database;
using AppTask.Navigation;
using AppTask.Repositories;
using AppTask.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using UraniumUI;

namespace AppTask
{
    public static class MauiProgram
    {
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
                .UseUraniumUI()
                .UseUraniumUIMaterial();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            #region D.I Database
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "apptask.db");
            builder.Services.AddDbContext<AppTaskContext>(options =>
            options.UseSqlite($"Filename={databasePath}"));
            #endregion

            #region D.I Interfaces
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ITaskModelRepository, TaskModelRepository>();
            #endregion

            #region D.I Views
            builder.Services.AddTransient<StartPage>();
            builder.Services.AddTransient<AddEditTaskPage>();
            #endregion

            return builder.Build();
        }
    }
}
