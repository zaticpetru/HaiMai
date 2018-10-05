using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using UserStore.BLL.Services;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Interfaces;

[assembly: OwinStartup(typeof(UserStore.WEB.App_Start.Startup))]

namespace UserStore.WEB.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<IEventService>(CreateEventService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
        private IEventService CreateEventService()
        {
            return serviceCreator.CreateEventService("DefaultConnection");
        }
    }
}