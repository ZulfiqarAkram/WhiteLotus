using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiteLotusProject.Models;

namespace WhiteLotusProject.ViewModels
{
    public class ClassFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
       // [FutureDate]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        
        [Required]
        //[ValidTime]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        [Required]
        public string Level { get; set; }

        public string Duration { get; set; }
       
        public string Description { get; set; }

        public bool? IsCanceled { get; set; }

        [Required]
        public int TeacherId { get; set; }
        
        public IEnumerable<Teacher> Teacher { get; set; }


        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}