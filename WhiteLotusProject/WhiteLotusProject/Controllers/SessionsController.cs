using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WhiteLotusProject.Models;
using WhiteLotusProject.ViewModels;

namespace WhiteLotusProject.Controllers
{
    [Authorize]
    public class SessionsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var classes = db.Classes.Include(a => a.Teacher);
            var workshops = db.Workshops.Include(a => a.Teacher);
            var userId = User.Identity.GetUserId();
            var viewModel = new SessionsViewModel
            {
               Classes = classes.Where(c=>c.DateTime> DateTime.Now).ToList(),
               Workshops = workshops.Where(c=>c.DateTime > DateTime.Now).ToList(),
               ReserveClassLookup = GetReserveClasses(userId).ToLookup(c=>c.ClassId),
               ReserveWorkshopLookup = GetReserveWorkshops(userId).ToLookup(c => c.WorkshopId),
               Heading = "Upcoming Sessions"
            };
            return View(viewModel);
        }

        public IEnumerable<ReserveWorkshop> GetReserveWorkshops(string userId)
        {
            return db.ReserveWorkshops
                .Where(a => a.ClientId == userId)
                .ToList();
        }
        public IEnumerable<ReserveClass> GetReserveClasses(string userId)
        {
            return db.ReserveClasses
                .Where(a => a.ClientId == userId)
                .ToList();
        }
        
    }
}