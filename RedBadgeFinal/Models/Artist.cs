using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedBadgeFinal.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}