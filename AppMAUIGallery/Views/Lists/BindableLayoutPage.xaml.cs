using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views.Lists;

public partial class BindableLayoutPage : ContentPage
{
    private readonly IMovieRepository _movieRepository;

    public BindableLayoutPage(IMovieRepository movieRepository)
	{
		InitializeComponent();
		_movieRepository = movieRepository;

        GetMovies();
    }

    private async Task GetMovies()
    {
        try
        {
            var layout = VerticalStackLayoutControl;
            var list = await _movieRepository.GetMoviesAsync(); //Movies

            BindableLayout.SetItemsSource(layout, list);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}