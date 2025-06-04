using AppShoppingCenter.Models.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Cinemas
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Movie> movies;

        private ICinemaService _service;
        public ListPageViewModel(ICinemaService service)
        {
            //var service = App.Current.Handler.MauiContext.Services.GetService<CinemaService>();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GetMovies();
        }

        // Esse construtor extra faz ligação com o construtor acima, permitindo usar um BindingContext direto na View.xaml sem necessidade de parâmetro no construtor.
        public ListPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<ICinemaService>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {

        }

        private async void GetMovies()
        {
            movies = await _service.GetMovies();
        }

        [RelayCommand]
        private async void TapMovieGoDetailPage(Movie movie)
        {
            var param = new Dictionary<string, object>
            {
                { "movie", movie }
            };

            await Shell.Current.GoToAsync("detail", param);
        }
    }
}
