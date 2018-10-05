using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private ApplicationContext db;
        public EventRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Event> GetAll()
        {
            return db.Events
                .Include(x => x.Admin)
                .Include(x => x.Moderators)
                .Include(x => x.Reports);
            // to do a extension method - include all 
            // https://codereview.stackexchange.com/questions/30839/dbsett-includeall-method
        }
        public Event Get(int id)
        {
            return db.Events.Find(id);
        }
        public void Create(Event item)
        {
            db.Events.Add(item);
        }
        public void Update(Event item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Event> Find(Func<Event, Boolean> predicate)
        {
            return db.Events
                .Include(x => x.Admin)
                .Include(x => x.Moderators)
                .Include(x => x.Reports)
                .Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Event item = db.Events.Find(id);
            if (item != null)
                db.Events.Remove(item);
        }
    }
}
