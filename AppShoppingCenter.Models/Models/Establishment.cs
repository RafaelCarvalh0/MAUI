using AppShoppingCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Models.Models
{
    public class Establishment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Localization { get; set; }
        public string Phone { get; set; }
        public EstablishmentType Type { get; set; }

        [Required]
        public string Cover { get; set; }
        [Required]
        public string Logo { get; set; }
    }
}
