namespace AppMAUIGallery.Views.Components.Forms;

public partial class PickerPage : ContentPage
{
	public PickerPage()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var component = ((Picker)sender);

		//component.SelectedIndex = 4;
		//component.SelectedItem = component.ItemsSource[0];
		LblValue.Text = $"Brand name: {component.SelectedItem.ToString()}";
    }
}