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
        public DateTimeOffset DataIn {  get; set; }
        public DateTimeOffset DataOut { get; set; } //Date - Pay
        public DateTimeOffset DataTolerance { get; set; }
        public double Price { get; set; }
    }
}
