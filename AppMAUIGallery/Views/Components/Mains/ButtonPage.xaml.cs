namespace AppMAUIGallery.Views.Components.Mains;

public partial class ButtonPage : ContentPage
{
	public ButtonPage()
	{
		InitializeComponent();
	}

    private void Button_Pressed(object sender, EventArgs e)
    {
        lblLog.Text += $"\nPressed: {DateTime.Now}";
    }

    private void Button_Released(object sender, EventArgs e)
    {
        lblLog.Text += $"\nReleased: {DateTime.Now}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        lblLog.Text += $"\nClicked: {DateTime.Now}";
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        lblLog.Text = string.Empty;
    }

    
}