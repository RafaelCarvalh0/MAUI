namespace AppMAUIGallery.Views.Styles;

public partial class VisualStateManagerPage : ContentPage
{
	public VisualStateManagerPage()
	{
		InitializeComponent();
	}

    private async void OnTappedChangeVisualState(object sender, TappedEventArgs e)
    {
		var label = (Label)sender;
		VisualStateManager.GoToState(label, "Tapped");

		if(label.Text.ToLower().Contains("google"))
            await Launcher.OpenAsync("https://www.google.com");

		else if(label.Text.ToLower().Contains("microsoft"))
            await Launcher.OpenAsync("https://www.microsoft.com");
    }
}