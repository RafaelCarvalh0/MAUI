namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImageButtonPage : ContentPage
{
	public bool buttonState = false;
	public ImageButtonPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		buttonState = !buttonState;

		var button = (ImageButton)sender;

		var porweroff = "poweroff.png";
		var porweron = "poweron.png";

        button.Source = buttonState is false ? ImageSource.FromFile(porweroff) : ImageSource.FromFile(porweron);
    }
}