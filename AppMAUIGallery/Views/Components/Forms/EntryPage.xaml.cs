using Microsoft.Maui;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();
	}

    private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
    {
		//R
		var OldText = e.OldTextValue;
		var NewText = e.NewTextValue;

		LblText.Text = $"Old: {OldText}  |  New: {NewText}";
    }

    private void TextInput_Completed(object sender, EventArgs e)
    {
		LblText.Text = "Concluído!";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (TextInput.Text.Length == 0)
            LblText.Text = string.Empty;
    }
}