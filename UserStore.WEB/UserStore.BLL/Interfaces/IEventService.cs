using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.BLL.DTO;

namespace UserStore.BLL.Interfaces
{
    public interface IEventService : IDisposable
    {
        void MakeEvent(EventDTO eventDTO);
        EventDTO GetEvent(int? id);
        UserDTO GetAdmin();
        IEnumerable<UserDTO> GetModerators();
        IEnumerable<ReportDTO> GetReports();
    }
}
