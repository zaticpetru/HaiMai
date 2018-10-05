using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        private ApplicationContext db;
        public ReportRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Report> GetAll()
        {
            return db.Reports;
        }
        public Report Get(int id)
        {
            return db.Reports.Find(id);
        }
        public void Create(Report item)
        {
            db.Reports.Add(item);
        }
        public void Update(Report item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Report> Find(Func<Report, Boolean> predicate)
        {
            return db.Reports.Where(predicate).ToList();
        }
        public void Delete(int id) {
            Report item = db.Reports.Find(id);
            if (item != null)
                db.Reports.Remove(item);
        }
    }
}
