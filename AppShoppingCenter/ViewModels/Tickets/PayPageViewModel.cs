using CommunityToolkit.Mvvm.ComponentModel;
using AppShoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using AppShoppingCenter.Constants;
using AppShoppingCenter.Libraries.Storages;

namespace AppShoppingCenter.ViewModels.Tickets
{
    [QueryProperty(nameof(Ticket), "ticket")]
    public partial class PayPageViewModel : ObservableObject
    {
        private Ticket ticket;

        // Encapsulamento !
        public Ticket Ticket
        {
            get { return ticket; }
            set
            {
                GenerateDateOutAndTolerance(value);
                GeneratePrice(value);
                SetProperty(ref ticket, value);
            }

        }

        private readonly TicketPreferenceStorage _ticketPreferenceStorage;

        public PayPageViewModel(TicketPreferenceStorage ticketPreferenceStorage)
        {
            _ticketPreferenceStorage = ticketPreferenceStorage;
        }

        public PayPageViewModel() : this(App.Current.Handler.MauiContext.Services.GetRequiredService<TicketPreferenceStorage>() ?? throw new InvalidOperationException("Serviço não resolvido"))
        {

        }

        [ObservableProperty]
        private string pixCode = "00020126580014BR.GOV.BCB.PIX0117exemplo@dominio.com0212EXEMPLO1235204000053039865405123.455802BR5913JOAO DA SILVA6009SAO PAULO62070503***6304D3B7";

        [RelayCommand]
        private async void CopyAndPaste()
        {
            await Clipboard.Default.SetTextAsync(PixCode);
            await Task.Delay(30000);

            await _ticketPreferenceStorage.Save(Ticket);

            //tickets/pay
            await Shell.Current.GoToAsync($"../{Routes.TicketsResult.RelativePath}", true, new Dictionary<string, object>
            {
                { "ticket", Ticket }
            });
        }

        private void GenerateDateOutAndTolerance(Ticket ticket)
        {
            var rd = new Random();
            int hours = rd.Next(0, 12);
            int minutes = rd.Next(0, 60);

            ticket.DateOut = ticket.DateIn.AddHours(hours).AddMinutes(minutes);
            ticket.DateTolerance = ticket.DateOut.AddMinutes(30);
        }

        private double HourValue = 0.10;
        private void GeneratePrice(Ticket ticket)
        {
            var dif = ticket.DateOut.Ticks - ticket.DateIn.Ticks;
            var difTs = new TimeSpan(dif);

            ticket.Price = difTs.TotalMinutes * HourValue;
        }
    }
}
