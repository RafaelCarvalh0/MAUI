namespace AppMAUIGallery.Views.Components.Forms;

public partial class CheckBoxPage : ContentPage
{
	private List<string> Tecnologies = new();
	public CheckBoxPage()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		bool value = e.Value;
        LblStatus.Text = string.Empty;

        CheckBox checkbox = ((CheckBox)sender);
        HorizontalStackLayout stack = (HorizontalStackLayout)checkbox.Parent;
        Label label = (Label)stack.Children[1];

        if (value is true)
			Tecnologies.Add(label.Text);

		else
			Tecnologies.Remove(label.Text);
		
        foreach (var item in Tecnologies)
        {
            LblStatus.Text += $"{item} \n";
        }
    }
}