using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.DAL.Identity;
using UserStore.DAL.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private EventRepository eventRepository;
        private ReportRepository reportRepository;

        public IdentityUnitOfWork(string connectionString)
        {
            this.db = new ApplicationContext(connectionString);
            this.userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this.db));
            this.roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(this.db));
            this.clientManager = new ClientManager(this.db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public IClientManager ClientManager
        {
            get { return clientManager; }
        }
        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Event> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepository(db);
                return eventRepository;
            }
        }

        public IRepository<Report> Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(db);
                return reportRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
