using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiteLotusProject.Models
{
    public class ReserveWorkshop
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int WorkshopId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public string ClientId { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }

        public Workshop Workshop { get; set; }
        public ApplicationUser Client { get; set; }
    }
}