using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views.Lists;

public partial class DataTemplateSelectorPage : ContentPage
{
    private readonly IMovieRepository _movieRepository;
    public DataTemplateSelectorPage(IMovieRepository movieRepository)
	{
		InitializeComponent();
        _movieRepository = movieRepository;

        GetMovies();
    }

    private async Task GetMovies()
    {
        try
        {
            var movies = await _movieRepository.GetMoviesAsync(); //Movies
            CollectionViewControl.ItemsSource = movies;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}