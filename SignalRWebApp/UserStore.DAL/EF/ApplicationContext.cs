using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        static ApplicationContext()
        {
            Database.SetInitializer(new ContextInit());
        }
        public ApplicationContext(string connectionString) 
            : base(connectionString)
        {
        }

    }
}
