using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace UserStore.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        //public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
