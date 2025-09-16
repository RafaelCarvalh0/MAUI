using AppShoppingCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicket(string TicketNumber);
        Task<List<Ticket>> GetTickets();
    }

    public class TicketService : ITicketService
    {
        private List<Ticket> tickets = new List<Ticket>()
        {
            new Ticket()
            {
                Id = 1,
                TicketNumber = "209883557324",
                DateIn = new DateTimeOffset(2025, 06, 11, 12, 00, 00, TimeSpan.FromHours(-3)) 
            },
            new Ticket()
            {
                Id = 2,
                TicketNumber = "320683687451",
                DateIn = new DateTimeOffset(2025, 06, 11, 15, 00, 00, TimeSpan.FromHours(-3))
            }
        };


        public async Task<Ticket> GetTicket(string TicketNumber)
        {
            return await Task.Run(() => tickets.FirstOrDefault(t => t.TicketNumber == TicketNumber));
        }

        public async Task<List<Ticket>> GetTickets()
        {
            // TODO - Pegar os tickets armazenados no dispositivo ou na API.
            return new List<Ticket> { new Ticket() };
        }
    }
}
