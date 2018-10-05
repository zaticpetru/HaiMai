using Microsoft.AspNet.Identity.EntityFramework;

namespace UserStore.DAL.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}