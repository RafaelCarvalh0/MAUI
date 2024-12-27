using AppMAUIGallery.ViewModels;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class SearchBarPage : ContentPage
{
	public SearchBarPage()
	{
		InitializeComponent();
	}

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
		//string value = ((SearchBar)sender).Text;
		//LblValue.Text = $"Searched word: {value}";

        //MVVM
        if (BindingContext is SearchBarViewModel viewModel)
        {
            //if (!string.IsNullOrWhiteSpace(viewModel.Text))
            //    LblValue.Text = $"Texto de busca: {viewModel.Text}";

            //else
            //    LblValue.Text = string.Empty;
        }
    }
}