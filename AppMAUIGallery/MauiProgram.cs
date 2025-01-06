using Microsoft.Extensions.Logging;
using AppMAUIGallery;
using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views;
using AppMAUIGallery.Views.Lists;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Components.Visuals;
using AppMAUIGallery.Views.Components.Forms;
using AppMAUIGallery.Views.Cells;

namespace AppMAUIGallery
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();

            Routing.RegisterRoute("Menu", typeof(Menu));

            var app = builder.Build();
            Services = app.Services; // Armazena o provedor de serviços
            return app;
        }


        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            mauiAppBuilder.Services.AddSingleton<IMovieRepository, MovieRepository>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ViewModels.MainViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.SearchBarViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<StackLayoutPage>();
            mauiAppBuilder.Services.AddTransient<GridLayoutPage>();
            mauiAppBuilder.Services.AddTransient<AbsoluteLayoutPage>();
            mauiAppBuilder.Services.AddTransient<FlexLayoutPage>();

            mauiAppBuilder.Services.AddTransient<BoxViewPage>();
            mauiAppBuilder.Services.AddTransient<LabelPage>();
            mauiAppBuilder.Services.AddTransient<ButtonPage>();
            mauiAppBuilder.Services.AddTransient<ImagePage>();
            mauiAppBuilder.Services.AddTransient<ImageButtonPage>();

            mauiAppBuilder.Services.AddTransient<FramePage>();
            mauiAppBuilder.Services.AddTransient<BorderPage>();
            mauiAppBuilder.Services.AddTransient<ShadowPage>();

            mauiAppBuilder.Services.AddTransient<EntryPage>();
            mauiAppBuilder.Services.AddTransient<EditorPage>();
            mauiAppBuilder.Services.AddTransient<CheckBoxPage>();
            mauiAppBuilder.Services.AddTransient<RadioButtonPage>();
            mauiAppBuilder.Services.AddTransient<SwitchPage>();
            mauiAppBuilder.Services.AddTransient<StepperPage>();
            mauiAppBuilder.Services.AddTransient<SliderPage>();
            mauiAppBuilder.Services.AddTransient<TimerPickerPage>();
            mauiAppBuilder.Services.AddTransient<DatePickerPage>();
            mauiAppBuilder.Services.AddTransient<SearchBarPage>();
            mauiAppBuilder.Services.AddTransient<PickerPage>();

            mauiAppBuilder.Services.AddTransient<TextCellPage>();
            mauiAppBuilder.Services.AddTransient<ImageCellPage>();
            mauiAppBuilder.Services.AddTransient<SwitchCellPage>();
            mauiAppBuilder.Services.AddTransient<EntryCellPage>();
            mauiAppBuilder.Services.AddTransient<ViewCellPage>();

            mauiAppBuilder.Services.AddTransient<TableViewPage>();
            mauiAppBuilder.Services.AddTransient<PickerListPage>();
            mauiAppBuilder.Services.AddTransient<ListViewPage>();
            mauiAppBuilder.Services.AddTransient<CollectionViewPage>();
            mauiAppBuilder.Services.AddTransient<CarouselViewPage>();
            mauiAppBuilder.Services.AddTransient<BindableLayoutPage>();

            return mauiAppBuilder;
        }
    }
}
