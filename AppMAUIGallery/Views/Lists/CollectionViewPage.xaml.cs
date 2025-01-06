using AppMAUIGallery.Repositories;
using AppMAUIGallery.Views.Lists.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace AppMAUIGallery.Views.Lists;

public partial class CollectionViewPage : ContentPage
{
    //For movies
    ObservableCollection<Movie> Movies = new ObservableCollection<Movie>();

    //For Group Movies
    ObservableCollection<GroupMovie> GroupMovies = new ObservableCollection<GroupMovie>();

    int countMovies = 0;
    private readonly IMovieRepository _movieRepository;

    public CollectionViewPage(IMovieRepository movieRepository)
    {
        InitializeComponent();
        _movieRepository = movieRepository;


        //GetMovies();
        GetGroupMovies();

        //Método para ObservableCollection only
        //AddMovies();
        //CollectionViewControl.ItemsSource = Movies;
    }

    // Necessário
    public CollectionViewPage() : this(MauiProgram.Services.GetRequiredService<IMovieRepository>())
    {

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

    private async Task GetGroupMovies()
    {
        try
        {
            MovieRepository.GetGroupList().ForEach(groupMovie => GroupMovies.Add(groupMovie));

            //foreach (var groupMovie in groupMovies)
            //{
            //    ObservableMovies.Add(groupMovie);
            //}

            CollectionViewControl.ItemsSource = GroupMovies; //Groups
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        try
        {
            //var refreshComponent = (RefreshView)sender;
            await Task.Delay(2000);
            //var movies = await _movieRepository.GetMoviesAsync();
            var movies = MovieRepository.GetGroupList();
            //var moviesByYear = movies.OrderBy(x => x.LaunchYear).ToList();

            CollectionViewControl.ItemsSource = movies;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            ((RefreshView)sender).IsRefreshing = false;
        }
    }

    private void CollectionViewControl_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        //AddMovies();
        GetGroupMovies();
    }

    private void AddMovies()
    {
        for (int i = 0; i < 20; i++)
        {
            Movie movie = new Movie
            {
                Id = countMovies++,
                Title = $"Movie {countMovies}",
                Description = $"Description {countMovies}",
                LaunchYear = 2024,
                Duration = new TimeSpan(2, 0, 0)
            };
            Movies.Add(movie);
        }
    }

    private void CollectionViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //CollectionView collection = (CollectionView)sender;
        StringBuilder sb = new StringBuilder();
        foreach (Movie movie in e.CurrentSelection)
        {
            sb.Append(movie.Title + $"\n");
        }
        //var selecaoAnterior = e.PreviousSelection;

        LblSelectedMovies.Text = $"{sb.ToString()}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Usando Indice para scrollar, não recomendado pois pode ser complicado.
        //Esse indice 10 navega até o filme Super man pois os headers e footers tbem são indices.
        //CollectionViewControl.ScrollTo(10, position: ScrollToPosition.Start);

        //Pega os itens que estão na CollectionView
        var group = (ObservableCollection<GroupMovie>)CollectionViewControl.ItemsSource;
        var item = group[2][1];

        CollectionViewControl.ScrollTo(item, position: ScrollToPosition.Start);
    }

    private void CollectionViewControl_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        ////Exibe o espaçamento que ocorreu do ponto inicial até o ponto final do scroll
        //e.VerticalDelta;

        ////Mostra o posicionamento atual do scroll vertical
        //e.VerticalOffset;

        //// Mostra qual o indice do primeiro item atual
        //e.FirstVisibleItemIndex;

        //// Mostra qual o indice do item do meio
        //e.CenterItemIndex;

        //// Mostra qual o indice do último item
        //e.LastVisibleItemIndex;

        //Utilizando esses recursos acima tbem é possivel utilizar scroll infinito através de cálculos.

        LblScrollStatus.Text = $"Posicionamento: {e.VerticalOffset.ToString("N2")} - Espaçamento: {e.VerticalDelta.ToString("N2")}";
    }
}