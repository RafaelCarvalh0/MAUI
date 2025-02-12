using AppMAUIGallery.Libraries.Fix;
using AppMAUIGallery.Views;

namespace AppMAUIGallery;

public partial class MainFlyout : FlyoutPage
{
    private readonly IServiceProvider _serviceProvider;

    public MainFlyout(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        // Define o menu do Flyout
        Flyout = _serviceProvider.GetRequiredService<Menu>();

        // Define a página principal no Detail
        Detail = new NavigationPage(_serviceProvider.GetRequiredService<MainPage>());
    }

    private void FlyoutPage_IsPresentedChanged(object sender, EventArgs e)
    {
        KeyboardFix.HideKeyboard();
    }
}