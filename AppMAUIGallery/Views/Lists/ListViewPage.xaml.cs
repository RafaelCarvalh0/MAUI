using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views.Lists.Models;

namespace AppMAUIGallery.Views.Lists;

public partial class ListViewPage : ContentPage
{
    private readonly IMovieRepository _movieRepository;
    public ListViewPage(IMovieRepository movieRepository)
    {
        InitializeComponent();
        _movieRepository = movieRepository;
    }

    public ListViewPage() : this(MauiProgram.Services.GetRequiredService<IMovieRepository>())
    {

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var movies = await _movieRepository.GetMoviesAsync();
        var GroupedMovies = MovieRepository.GetGroupList();

        ListViewControl.ItemsSource = GroupedMovies.Take(2);
    }

    private void ListViewControl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var movie = ((Movie)e.SelectedItem);

        App.Current.MainPage.DisplayAlert("Selected movie!", movie.Title, "OK");
    }

    private async void ListViewControl_Refreshing(object sender, EventArgs e)
    {
        try
        {
            await Task.Delay(2000);
            //var movies = await _movieRepository.GetMoviesAsync();
            var movies = MovieRepository.GetGroupList();
            //var moviesByYear = movies.OrderBy(x => x.LaunchYear).ToList();

            ListViewControl.ItemsSource = movies;//moviesByYear;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            ListViewControl.IsRefreshing = false;
        }
    }

    private void ListViewControl_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var movie = ((Movie)e.Item);

        App.Current.MainPage.DisplayAlert("Tapped movie!", movie.Title, "OK");
    }
}