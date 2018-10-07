using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.Interfaces;

namespace SignalRWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserSerice
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}