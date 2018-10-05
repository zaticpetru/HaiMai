using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.WEB.Models;

namespace UserStore.WEB.Controllers
{
    public class EventController : Controller
    {


        private IUserService userService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IEventService eventService
        {
            get
            {
                return HttpContext.GetOwinContext().Get<IEventService>();
            }
        }
        // GET: Event
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDTOs = userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserModel>>(userDTOs);

            return View(users);
        }
    }
}