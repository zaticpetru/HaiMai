using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class ChatController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}