using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteLotusProject.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public string Duration { get; set; }
        public string Venue { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public bool IsCanceled { get; set; }

        public Teacher Teacher { get; set; }
    }
}