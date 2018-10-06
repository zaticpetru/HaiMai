using System;
using System.Collections.Generic;
using System.Data.Entity;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ContextInit : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            db.Events.Add(new Event
            {
               // Admin = new ClientProfile { Name = "her", Address = "her", Id = "1" },
                Location = "hz gde",
                Name = "pizdet mne",
                Start = DateTime.UtcNow,
                Finish = DateTime.Now,
                Id = 1,
                Reports = new List<Report>() { new Report { Information = "huitam", IsModerated = true, Publisher = "pesdiuk", DateTime = DateTime.Now} }
            });
            // to add some initial data
            db.SaveChanges();
        }
    }
}
