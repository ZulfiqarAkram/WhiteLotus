using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteLotusProject.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Day { get; set; }
        public DateTime DateTime { get; set; }
        public string Level { get; set; }
        public string Duration { get; set; }
        public int? Capacity { get; set; }
        public string Description { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public bool? IsCanceled { get; set; }
        public Teacher Teacher { get; set; }
    }
}