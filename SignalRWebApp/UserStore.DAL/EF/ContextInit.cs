using System;
using System.Collections.Generic;
using System.Data.Entity;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ContextInit : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
           
            db.SaveChanges();
        }
    }
}
