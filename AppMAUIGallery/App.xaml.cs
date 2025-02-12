using AppMAUIGallery;

namespace AppMAUIGallery
{
    public partial class App : Application
    {
        public App(MainFlyout flyout)
        {
            InitializeComponent();
            MainPage = flyout; //new AppFlyout(serviceProvider.GetRequiredService<FlyoutPage>());
        }
    }
}
