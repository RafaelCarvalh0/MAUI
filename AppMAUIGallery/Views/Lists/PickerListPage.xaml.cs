using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views.Lists;

public partial class PickerListPage : ContentPage
{
	private readonly IMovieRepository _movieRepository;
	public PickerListPage()
	{
		InitializeComponent();
		_movieRepository = MauiProgram.Services.GetRequiredService<IMovieRepository>();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            var categories = await _movieRepository.GetMoviesAsync();
			PickerControl.ItemsSource = categories;
        }
		catch (Exception)
		{

			throw;
		}
    }
}