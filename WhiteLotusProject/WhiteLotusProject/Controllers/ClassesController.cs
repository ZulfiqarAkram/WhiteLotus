using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WhiteLotusProject.Models;
using WhiteLotusProject.ViewModels;

namespace WhiteLotusProject.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Index()
        {
            var classes = db.Classes.Include(a => a.Teacher);
            return View(classes.ToList());

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            @class.Teacher = db.Teachers.Find(@class.TeacherId);
            if (@class.Capacity == null)
                @class.Capacity = 0;
            if (@class.IsCanceled == null)
                @class.IsCanceled = false;
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Create()
        {
           

            var viewModel = new ClassFormViewModel
            {
                Teacher = db.Teachers.ToList()
            };

            return View("ClassCreateForm",viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var @class=new Class
                {
                    Title = viewModel.Title,
                    Day = viewModel.Day,
                    DateTime = viewModel.GetDateTime(),
                    Level = viewModel.Level,
                    Duration = viewModel.Duration,
                    Description = viewModel.Description,
                    TeacherId = viewModel.TeacherId
                };
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            var viewModel = new ClassFormViewModel
            {
                Id = @class.Id,
                Title = @class.Title,
                Day = @class.Day,
                Date = @class.DateTime.ToString("d MMM yyyy"),
                Time = @class.DateTime.ToString("HH:mm"),
                TeacherId = @class.TeacherId,
                Teacher = db.Teachers.ToList(),
                Level = @class.Level,
                Duration = @class.Duration,
                Description = @class.Description,
                IsCanceled = @class.IsCanceled.HasValue
            };
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View("Edit",viewModel);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassFormViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                var @class = new Class
                {
                    Id = formViewModel.Id,
                    Title = formViewModel.Title,
                    Day = formViewModel.Day,
                    DateTime = formViewModel.GetDateTime(),
                    TeacherId = formViewModel.TeacherId,
                    Description = formViewModel.Description,
                    Duration = formViewModel.Duration,
                    IsCanceled = formViewModel.IsCanceled,
                    Level = formViewModel.Level
                };

                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new ClassFormViewModel
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
            Class @class = db.Classes.Find(id);
            @class.Teacher = db.Teachers.Find(@class.TeacherId);
            if (@class.Capacity == null)
                @class.Capacity = 0;
            if (@class.IsCanceled == null)
                @class.IsCanceled = false;
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        [Authorize(Roles = "Admin,Manager,Instructor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
