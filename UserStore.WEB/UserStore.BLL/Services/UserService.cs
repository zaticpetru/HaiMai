using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Entities;
using UserStore.DAL.Interfaces;

namespace UserStore.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<OperationDetails> Create(UserDTO userDTO)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = userDTO.Email,
                    UserName = userDTO.Email
                };
                //var result = await Database.UserManager.CreateAsync(user, userDTO.Password);
                //if (result.Errors.Count() > 0)
                //    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                //adding role
                await Database.UserManager.CreateAsync(user, userDTO.Password);
                await Database.UserManager.AddToRoleAsync(user.Id, userDTO.Role);
                //creating client profile
                ClientProfile clientProfile = new ClientProfile
                {
                    Id = user.Id,
                    Address = userDTO.Address,
                    Name = userDTO.Name
                };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Registration succesefull", "");
            }
            else
            {
                return new OperationDetails(false, "user with same email exists", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;
            //finding user
            ApplicationUser user = await Database.UserManager.FindAsync(userDTO.Email, userDTO.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDTO, List<string> roles)
        {
            foreach(string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if(role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDTO);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
