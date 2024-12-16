namespace AppMAUIGallery.Views.Components.Mains;

public partial class LabelPage : ContentPage
{
	public LabelPage()
	{
		InitializeComponent();
	}

    private async void OnTapLink(object sender, TappedEventArgs e)
    {
        var label = (Label)sender;
        label.FormattedText.Spans[0].Text = "Clicked";

        await Task.Delay(1000);
        label.FormattedText.Spans[1].Text = "Modifiying the second span element";
    }
}