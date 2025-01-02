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
        ListViewControl.ItemsSource = movies.Take(2);
    }

    private void ListViewControl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var movie = ((Movie)e.SelectedItem);

        App.Current.MainPage.DisplayAlert("Selected movie!", movie.Title, "OK");
    }

    private async void ListViewControl_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(2000);
        var movies = await _movieRepository.GetMoviesAsync();
        var moviesByYear = movies.OrderBy(x => x.LaunchYear).ToList();

        ListViewControl.ItemsSource = moviesByYear;

        ListViewControl.IsRefreshing = false;
    }
}