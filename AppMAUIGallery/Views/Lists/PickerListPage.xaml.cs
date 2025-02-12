using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class PickerListPage : ContentPage
{
	private readonly IMovieRepository _movieRepository;
	public PickerListPage(IMovieRepository movieRepository)
	{
		InitializeComponent();
		_movieRepository = movieRepository;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            var categories = await _movieRepository.GetMoviesAsync();
			PickerControl.ItemsSource = categories;

			//PickerControl.SelectedIndex = 3;

			//Pega o nome do filme (Title)
			//var name = ((Movie)PickerControl.SelectedItem).Title;

			//Seta o nome do filme no picker
			//PickerControl.SelectedItem = categories[6];
        }
		catch (Exception)
		{

			throw;
		}
    }
}