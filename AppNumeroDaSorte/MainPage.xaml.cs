namespace AppNumeroDaSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void OnGenerateNumbers(object sender, EventArgs e)
    {
        //((Button)sender).Text = "";
        AppName.IsVisible = false;
        ContainerNumbers.IsVisible = true;
    }
}