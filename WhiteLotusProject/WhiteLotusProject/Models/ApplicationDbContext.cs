using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WhiteLotusProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ReserveClass> ReserveClasses { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<ReserveWorkshop> ReserveWorkshops { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<WhiteLotusProject.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}