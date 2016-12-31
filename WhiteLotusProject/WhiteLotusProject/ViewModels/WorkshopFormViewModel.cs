using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiteLotusProject.Models;

namespace WhiteLotusProject.ViewModels
{
    public class WorkshopFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        public string Duration { get; set; }

        public string Venue { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public bool IsCanceled { get; set; }

        public IEnumerable<Teacher> Teacher { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}