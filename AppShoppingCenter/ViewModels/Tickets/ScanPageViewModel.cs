using AppShoppingCenter.Constants;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ScanPageViewModel : ObservableObject
    {
        private readonly ITicketService _ticketService;

        [ObservableProperty]
        private string ticketNumber;

        public ScanPageViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // Esse construtor extra faz ligação com o construtor acima, permitindo usar um BindingContext direto na View.xaml sem necessidade de parâmetro no construtor.
        public ScanPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<ITicketService>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {

        }

        [RelayCommand]
        private async void Scan()
        { 
            await Shell.Current.GoToAsync("pay", true, new Dictionary<string, object>
            {
                { "ticketNumber", TicketNumber }
            });
        }

        [RelayCommand]
        private async void CheckTicketNumber()
        {
            if (TicketNumber?.Trim()?.Length < 12)
                return;

            //TODO Verificar se o código existe no Banco/API/Mock.
            var ticket = await _ticketService.GetTicket(TicketNumber);

            //TODO CASE Mensagem de alerta.
            if(ticket is null)
            {
                App.Current.MainPage.DisplayAlert("Ticket não encontrado!", $"Não localizamos um ticket com o número {TicketNumber}.", "OK");
                return;
            }

            var param = new Dictionary<string, object>()
            {
                { "ticket", ticket }
            };

            //TODO Navegar para a página Pay.
            if (TicketNumber?.Trim()?.Length is 12) //is 15
            {
                await Shell.Current.GoToAsync(Routes.TicketsPay.RelativePath, true, param);
                TicketNumber = string.Empty;
            }

        }

        [RelayCommand]
        private async void List()
        {
            await Shell.Current.GoToAsync(Routes.TicketsList.RelativePath, true);
        }
    }
}
