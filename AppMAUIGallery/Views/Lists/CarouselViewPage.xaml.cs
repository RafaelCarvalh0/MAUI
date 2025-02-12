using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views.Lists;

public partial class CarouselViewPage : ContentPage
{
    private readonly IMovieRepository _movieRepository;
    public CarouselViewPage(IMovieRepository movieRepository)
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
            CarouselViewControl.ItemsSource = movies;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CarouselViewControl_PositionChanged(object sender, PositionChangedEventArgs e)
    {

    }

    private void CarouselViewControl_RemainingItemsThresholdReached(object sender, EventArgs e)
    {

    }
}