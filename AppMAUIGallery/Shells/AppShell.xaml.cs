using AppMAUIGallery.Shells.Pages;

namespace AppMAUIGallery.Shells;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Routing.UnRegisterRoute();
		Routing.RegisterRoute("page01step01", typeof(Page01Step01));
		Routing.RegisterRoute("page01step02", typeof(Page01Step02));
		Routing.RegisterRoute("page02step01withparameters", typeof(Page02Step01WithParameters));
	}

    private async void BackToGallery(object sender, EventArgs e)
    {
        App.Current.MainPage = App.Current?.Handler?.MauiContext?.Services?.GetService<MainFlyout>();
    }
}