using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.Models.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public TimeOnly Duration { get; set; }

        [Required]
        public string Cover { get; set; }
        [Required]
        public string Trailer { get; set; }
    }
}
