using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.Interfaces;

namespace UserStore.WEB.Controllers
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
        [Authorize(Roles ="admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}