using System.Collections.Generic;
using System.Linq;
using WhiteLotusProject.Models;

namespace WhiteLotusProject.ViewModels
{
    public class SessionsViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Workshop> Workshops { get; set; }
        public ILookup<int,ReserveClass> ReserveClassLookup { get; set; }
        public ILookup<int, ReserveWorkshop> ReserveWorkshopLookup { get; set; }
        public string Heading { get; set; }
    }
}