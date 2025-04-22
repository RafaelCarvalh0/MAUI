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
using UraniumUI;
using AppMAUIGallery.Views.Styles;
using AppMAUIGallery.Views.Animations;
using AppMAUIGallery.Views.Utils;
using CommunityToolkit.Maui;
using AppMAUIGallery.Views.CommunityMaui;

namespace AppMAUIGallery
{
    public static class MauiProgram
    {
        //public static IServiceProvider Services { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Icons.ttf", "Icons");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Foldit-Bold.ttf", "FolditBold");
                    fonts.AddFont("Foldit-Medium.ttf", "FolditMedium");
                    fonts.AddFontAwesomeIconFonts();
                })
                .RegisterInterfaces()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .RegisterViewModels()
                .RegisterViews();

            //Routing.RegisterRoute("Menu", typeof(Menu));

            return builder.Build();
        }


        public static MauiAppBuilder RegisterInterfaces(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IGroupComponentRepository, GroupComponentRepository>();
            builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<ViewModels.MainViewModel>();
            builder.Services.AddSingleton<ViewModels.SearchBarViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            // Initial screens
            builder.Services.AddSingleton<MainFlyout>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Menu>();

            builder.Services.AddTransient<StackLayoutPage>();
            builder.Services.AddTransient<GridLayoutPage>();
            builder.Services.AddTransient<AbsoluteLayoutPage>();
            builder.Services.AddTransient<FlexLayoutPage>();

            builder.Services.AddTransient<BoxViewPage>();
            builder.Services.AddTransient<LabelPage>();
            builder.Services.AddTransient<ButtonPage>();
            builder.Services.AddTransient<ImagePage>();
            builder.Services.AddTransient<ImageButtonPage>();
      
            builder.Services.AddTransient<FramePage>();
            builder.Services.AddTransient<BorderPage>();
            builder.Services.AddTransient<ShadowPage>();
          
            builder.Services.AddTransient<EntryPage>();
            builder.Services.AddTransient<EditorPage>();
            builder.Services.AddTransient<CheckBoxPage>();
            builder.Services.AddTransient<RadioButtonPage>();
            builder.Services.AddTransient<SwitchPage>();
            builder.Services.AddTransient<StepperPage>();
            builder.Services.AddTransient<SliderPage>();
            builder.Services.AddTransient<TimerPickerPage>();
            builder.Services.AddTransient<DatePickerPage>();
            builder.Services.AddTransient<SearchBarPage>();
            builder.Services.AddTransient<PickerPage>();
         
            builder.Services.AddTransient<TextCellPage>();
            builder.Services.AddTransient<ImageCellPage>();
            builder.Services.AddTransient<SwitchCellPage>();
            builder.Services.AddTransient<EntryCellPage>();
            builder.Services.AddTransient<ViewCellPage>();
       
            builder.Services.AddTransient<TableViewPage>();
            builder.Services.AddTransient<PickerListPage>();
            builder.Services.AddTransient<ListViewPage>();
            builder.Services.AddTransient<CollectionViewPage>();
            builder.Services.AddTransient<CarouselViewPage>();
            builder.Services.AddTransient<BindableLayoutPage>();
            builder.Services.AddTransient<DataTemplateSelectorPage>();

            builder.Services.AddTransient<ImplicitExplicitStyles>();
            builder.Services.AddTransient<GlobalStyle>();
            builder.Services.AddTransient<ApplyDerivedTypes>();
            builder.Services.AddTransient<InheritanceStyle>();
            builder.Services.AddTransient<StyleClassPage>();
            builder.Services.AddTransient<StaticDynamicResource>();
            builder.Services.AddTransient<Theme>();
            builder.Services.AddTransient<AppThemeBindingPage>();
            builder.Services.AddTransient<VisualStateManagerPage>();

            builder.Services.AddTransient<BasicAnimation>();

            builder.Services.AddTransient<BehaviorPage>();
            builder.Services.AddTransient<TriggerPage>();
            builder.Services.AddTransient<PlatformIdiomPage>();
            builder.Services.AddTransient<FontPage>();
            builder.Services.AddTransient<ColorPage>();

            builder.Services.AddTransient<AlertsPage>();

            return builder;
        }
    }
}
