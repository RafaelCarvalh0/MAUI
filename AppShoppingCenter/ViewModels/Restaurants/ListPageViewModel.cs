using AppShoppingCenter.Constants;
using AppShoppingCenter.Models.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Restaurants
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string textSearch;

        private List<Establishment> establishmentsFull; //Guarda todos os estabelecimentos, evitando sobrecarga e desgaste de API.

        [ObservableProperty]
        private List<Establishment> establishmentsFiltered;

        private IRestaurantService _service;

        public ListPageViewModel(IRestaurantService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            GetRestaurants();
        }

        // Esse construtor extra faz ligação com o construtor acima, permitindo usar um BindingContext direto na View.xaml sem necessidade de parâmetro no construtor.
        public ListPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<IRestaurantService>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {

        }

        private async void GetRestaurants()
        {
            try
            {
                establishmentsFull = await _service.GetRestaurants();
                EstablishmentsFiltered = establishmentsFull.ToList();
            }
            catch (Exception)
            {
                throw;
            }     
        }

        [RelayCommand]
        private void OnTextSearchChangedFilterList() => EstablishmentsFiltered = establishmentsFull.Where(x => x.Name.ToLower().Contains(textSearch.ToLower())).ToList();

        [RelayCommand]
        private async Task SelectionChanged(Establishment establishment)
        {
            if (establishment is not null)
            {
                var navigationParameter = new Dictionary<string, object>()
                {
                    { "establishment", establishment }
                };

                await Shell.Current.GoToAsync($"detail", navigationParameter);
            }
        }
    }
}
