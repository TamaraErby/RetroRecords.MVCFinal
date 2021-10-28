using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedBadgeFinal.Models
{
    public class Vinyl
    {
        [Key]
        public int VinylId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
}