using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }
    }
}