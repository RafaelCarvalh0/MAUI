using AppShoppingCenter.Models.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Stores
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string textSearch;

        private List<Establishment> establishmentsFull; //Guarda todos os estabelecimentos, evitando sobrecarga e desgaste de API.

        [ObservableProperty]
        private List<Establishment> establishmentsFiltered;

        private readonly IStoreService _storeService;
        public ListPageViewModel(IStoreService storeService)
        {
            _storeService = storeService;
            //_storeService = App.Current.Handler.MauiContext.Services.GetRequiredService<IStoreService>() ?? throw new InvalidOperationException("Serviço não resolvido");
            GetStores();
        }

        // Esse construtor extra faz ligação com o construtor acima, permitindo usar um BindingContext direto na View.xaml sem necessidade de parâmetro no construtor.
        public ListPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<IStoreService>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {

        }

        private async void GetStores()
        {
            try
            {
                establishmentsFull = await _storeService.GetStores();
                EstablishmentsFiltered = establishmentsFull.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
                //await DisplayAlertAsync("Erro", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private void OnTextSearchChangedFilterList() => EstablishmentsFiltered = establishmentsFull.Where(x => x.Name.ToLower().Contains(textSearch.ToLower())).ToList();

        [RelayCommand]
        private async void OnTapEstablishmentGoToDetailPage(Establishment establishment)
        {
            var navigationParameter = new Dictionary<string, object>()
            {
                { "establishment", establishment }
            };

            await Shell.Current.GoToAsync("detail", navigationParameter);
        }
    }
}
