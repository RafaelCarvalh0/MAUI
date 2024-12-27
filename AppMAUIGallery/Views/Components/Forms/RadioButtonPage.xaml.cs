namespace AppMAUIGallery.Views.Components.Forms;

public partial class RadioButtonPage : ContentPage
{
	public RadioButtonPage()
	{
		InitializeComponent();
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		object text = ((RadioButton)sender).Content;

        if (e.Value is true)
		{
            DisplayAlert("RadioButton", "You selected " + text, "OK");
            LblResultAsk01.Text = $"Você escolheu o valor {text}";
        }
    }
}