using System;
using System.Collections.Generic;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Interfaces;

namespace UserStore.BLL.Services
{
    public class EventService : IEventService
    {
        IUnitOfWork Database { get; set; }
        public EventService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeEvent(EventDTO eventDTO)
        {
               Database.ClientManager.
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetAdmin()
        {
            throw new NotImplementedException();
        }

        public EventDTO GetEvent(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetModerators()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportDTO> GetReports()
        {
            throw new NotImplementedException();
        }

        
    }
}
