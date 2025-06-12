using AppShoppingCenter.Libraries.Storages;
using AppShoppingCenter.Models.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Ticket> tickets;

        private readonly TicketPreferenceStorage _ticketPreferenceStorage;
        public ListPageViewModel(TicketPreferenceStorage ticketPreferenceStorage)
        {
            _ticketPreferenceStorage = ticketPreferenceStorage;
        }
        public ListPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<TicketPreferenceStorage>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {
            GetTickets();
        }

        private async void GetTickets()
        {
            Tickets = await _ticketPreferenceStorage.Load();
        }
    }
}
