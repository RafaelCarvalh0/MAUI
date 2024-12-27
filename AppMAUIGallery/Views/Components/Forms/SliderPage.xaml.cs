namespace AppMAUIGallery.Views.Components.Forms;

public partial class SliderPage : ContentPage
{
	public SliderPage()
	{
		InitializeComponent();
	}

    private void Slider_DragStarted(object sender, EventArgs e)
    {
        LblStatus.Text = "Draging!";
    }

    private void Slider_DragCompleted(object sender, EventArgs e)
    {
        LblStatus.Text = "Completed!";
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        LblValue.Text = $"Value {e.NewValue.ToString("N2")}";
    }
}