using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;

namespace UserStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDTO);
        void Delete(int id);
        void Update(UserDTO userDTO);
        UserDTO GetUser(int id);

        List<SimpleUserDTO> GetUsers();
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitialData(UserDTO adminDTO, List<string> roles);
    }
}
