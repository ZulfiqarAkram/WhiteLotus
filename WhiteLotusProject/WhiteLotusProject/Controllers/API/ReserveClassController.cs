using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WhiteLotusProject.Models;

namespace WhiteLotusProject.Controllers.API
{
    [Authorize]
    public class ReserveClassController : ApiController
    {
        ApplicationDbContext db=new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Enroll(int id)
        {
            var user = User.Identity.GetUserId();
            var isExist = db.ReserveClasses.Any(c => c.ClassId == id && c.ClientId == user);
            if (isExist)
                return BadRequest("Client already enroll in class");

            var reserveClass = new ReserveClass
            {
                ClassId = id,
                ClientId = user,
                DateTime = DateTime.Now
               
            };
            db.ReserveClasses.Add(reserveClass);

            var cls = db.Classes.Find(id);
            cls.Capacity++;
            
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var user = User.Identity.GetUserId();

            var reserveCls = db.ReserveClasses
                .SingleOrDefault(c => c.ClassId == id && c.ClientId == user);

            if (reserveCls == null)
                return NotFound();

            db.ReserveClasses.Remove(reserveCls);

            var cls = db.Classes.Find(id);
            cls.Capacity--;

            db.SaveChanges();
            return Ok(id);
        }
    }
}
