﻿using AppShoppingCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Services
{
    public class TicketService
    {
        public Ticket GetTicket(string TicketNumber)
        {
            return null;
        }

        public List<Ticket> GetTickets(int UserId)
        {
            return new List<Ticket> { new Ticket() };
        }
    }
}
