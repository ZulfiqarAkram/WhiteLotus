using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WhiteLotusProject.Models;

namespace WhiteLotusProject.Controllers.API
{
    [Authorize]
    public class ReserveWorkshopController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend(int id)
        {
            var user = User.Identity.GetUserId();
            var isExist = db.ReserveWorkshops.Any(c => c.WorkshopId == id && c.ClientId == user);
            if (isExist)
                return BadRequest("Client already enroll in workshop");

            var reserveClass = new ReserveWorkshop
            {
                WorkshopId= id,
                ClientId = user,
                DateTime = DateTime.Now
            };
            db.ReserveWorkshops.Add(reserveClass);
            db.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var user = User.Identity.GetUserId();

            var reserveWorkshop = db.ReserveWorkshops
                .SingleOrDefault(c => c.WorkshopId == id && c.ClientId == user);

            if (reserveWorkshop == null)
                return NotFound();

            db.ReserveWorkshops.Remove(reserveWorkshop);

            db.SaveChanges();
            return Ok(id);
        }
    }
}
