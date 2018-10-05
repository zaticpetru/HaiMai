using System;
using System.Collections.Generic;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
    public interface IEventService : IDisposable
    {
        void MakeEvent(EventDTO eventDTO);
        EventDTO GetEvent(int? id);
        UserDTO GetAdmin(int? EventId);
        IEnumerable<EventDTO> GetEvents();
        IEnumerable<UserDTO> GetModerators(int? EventId);
        IEnumerable<ReportDTO> GetReports(int? EventId);
    }
}
