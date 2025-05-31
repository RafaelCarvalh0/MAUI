using AppShoppingCenter.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace AppShoppingCenter
{
    public static class MauiProgram
    {
        //public static IServiceProvider Services { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Adicione esse handler para remover bordas do Entry
            //EntryHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            //{
            //#if ANDROID
            //    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            //    handler.PlatformView.Background = null;
            //    handler.PlatformView.SetPadding(0, 0, 0, 0);
            //#elif IOS
            //    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            //#endif
            //});

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                });

            #if DEBUG
    		    builder.Logging.AddDebug();
            #endif

            #region D.I Interfaces
            //Singleton : Cria uma única instância para toda a aplicação (Propriedades que não se alteram).
            builder.Services.AddSingleton<IStoreService, StoreService>();
            #endregion

            #region D.I Views
            //Transient : Cria uma nova instância a cada vez que é solicitado (Propriedades que se alteram a cada vez que é solicitado).
            builder.Services.AddTransient<AppShoppingCenter.Views.Stores.ListPage>();
            #endregion

            #region D.I ViewModels
            builder.Services.AddTransient<AppShoppingCenter.ViewModels.Stores.ListPageViewModel>();
            //builder.Services.AddTransient<AppShoppingCenter.ViewModels.Restaurants.ListPageViewModel>();
            //builder.Services.AddTransient<AppShoppingCenter.ViewModels.Cinemas.ListPageViewModel>();
            //builder.Services.AddTransient<AppShoppingCenter.ViewModels.Tickets.ListPageViewModel>();
            #endregion

            //Services = builder.Services.BuildServiceProvider();

            return builder.Build();
        }
    }
}
