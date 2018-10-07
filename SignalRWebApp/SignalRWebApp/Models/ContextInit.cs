using System.Data.Entity;

namespace SignalRWebApp.Models
{
    public class ContextInit : DropCreateDatabaseIfModelChanges<SignaRTestContext>
    {
        protected override void Seed(SignaRTestContext db)
        {
            {
                db.SaveChanges();
            }

        }
    }
}