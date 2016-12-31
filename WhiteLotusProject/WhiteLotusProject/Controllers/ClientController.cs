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
    public class ClientController : Controller
    {
        ApplicationDbContext db=new ApplicationDbContext();
        
        public new ActionResult Profile()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(user);
        
        }

        [Authorize(Roles = "Client")]
        public ActionResult MySessions()
        {
            //var classes = db.Classes.Include(a => a.Teacher);
            //var workshops = db.Workshops.Include(a => a.Teacher);
            var userId = User.Identity.GetUserId();


           var allClasses= db.ReserveClasses.Where(c => c.ClientId == userId && c.Class.DateTime > DateTime.Now)
               .Select(c=>c.ClassId)
               .ToList();
            var allWorkshops = db.ReserveWorkshops.Where(c => c.ClientId == userId && c.Workshop.DateTime > DateTime.Now)
                .Select(c => c.WorkshopId)
                .ToList();

            var viewModel = new SessionsViewModel
            {
                Classes = db.Classes.Where(c=>allClasses.Contains(c.Id)).Include(c=>c.Teacher).ToList(),
                Workshops = db.Workshops.Where(c=>allWorkshops.Contains(c.Id)).Include(c=>c.Teacher).ToList(),
                ReserveClassLookup = GetReserveClasses(userId).ToLookup(c => c.ClassId),
                ReserveWorkshopLookup = GetReserveWorkshops(userId).ToLookup(c => c.WorkshopId),
                Heading = "My Upcoming Sessions"
            };
            return View("~/Views/Sessions/Index.cshtml",viewModel);
           
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