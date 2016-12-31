using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WhiteLotusProject.Models;
using WhiteLotusProject.ViewModels;

namespace WhiteLotusProject.Controllers
{
    [Authorize]
    public class WorkshopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Index()
        {
            var workshops = db.Workshops.Include(w => w.Teacher);
            return View(workshops.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            workshop.Teacher = db.Teachers.Find(workshop.TeacherId);

            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Create()
        {
            var viewModel = new WorkshopFormViewModel
            {
                Teacher = db.Teachers.ToList()
            };
            return View("Create",viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkshopFormViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                var workshop = new Workshop
                {
                    Title = formViewModel.Title,
                    DateTime = formViewModel.GetDateTime(),
                    Duration = formViewModel.Duration,
                    Venue = formViewModel.Venue,
                    TeacherId = formViewModel.TeacherId,
                };

                db.Workshops.Add(workshop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new WorkshopFormViewModel
            {
                Teacher = db.Teachers.ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            var viewModel = new WorkshopFormViewModel
            {
                Id = workshop.Id,
                Title = workshop.Title,
                Date = workshop.DateTime.ToString("d MMM yyyy"),
                Time = workshop.DateTime.ToString("HH:mm"),
                TeacherId = workshop.TeacherId,
                Teacher = db.Teachers.ToList(),
                Duration = workshop.Duration,
                IsCanceled = workshop.IsCanceled,
                Venue = workshop.Venue
            };
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkshopFormViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                var workshop = new Workshop
                {
                    Id = formViewModel.Id,
                    Title = formViewModel.Title,
                    
                    DateTime = formViewModel.GetDateTime(),
                    TeacherId = formViewModel.TeacherId,

                    Duration = formViewModel.Duration,
                    IsCanceled = formViewModel.IsCanceled,
                   Venue = formViewModel.Venue
                };

                db.Entry(workshop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new WorkshopFormViewModel
            {
                Teacher = db.Teachers.ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }


        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workshop workshop = db.Workshops.Find(id);
            db.Workshops.Remove(workshop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
