using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Models.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string TicketNumber { get; set; }
        public DateTimeOffset DateIn {  get; set; }
        public DateTimeOffset DateOut { get; set; } //Date - Pay
        public DateTimeOffset DateTolerance { get; set; }
        public double Price { get; set; }
    }
}
