using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new ContextInit());
        }
        public ApplicationContext(string connectionString) : base(connectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
