using AutoMapper;
using System.Collections.Generic;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Entities;
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
            Event item = new Event
            {
                Id = eventDTO.Id,
                Admin = eventDTO.Admin,
                Finish = eventDTO.Finish,
                Location = eventDTO.Location,
                Moderators = eventDTO.Moderators,
                Name = eventDTO.Name,
                Reports = eventDTO.Reports,
                Start = eventDTO.Start
            };
            Database.Events.Create(item);
            Database.SaveAsync();
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public UserDTO GetAdmin(int? EventId)
        {
            if (EventId == null)
                throw new ValidationException("Event id is not setted", "");
            var Event = Database.Events.Get(EventId.Value);
            if (Event == null)
                throw new ValidationException("Event not found", "");
            UserDTO admin = new UserDTO
            {
                Id = Event.Admin.Id,
                Address = Event.Admin.Address,
                Email = Event.Admin.ApplicationUser.Email,
                Name = Event.Admin.Name,
                UserName = Event.Admin.ApplicationUser.UserName
            };
            return admin;
        }

        public EventDTO GetEvent(int? id)
        {
            if (id == null)
                throw new ValidationException("Event id is not setted", "");
            var Event = Database.Events.Get(id.Value);
            if (Event == null)
                throw new ValidationException("Event not found", "");
            return new EventDTO
            {
                Admin = Event.Admin,
                Finish = Event.Finish,
                Id = Event.Id,
                Location = Event.Location,
                Moderators = Event.Moderators,
                Name = Event.Name,
                Reports = Event.Reports,
                Start = Event.Start
            };
        }

        public IEnumerable<UserDTO> GetModerators(int? EventId)
        {
            if (EventId == null)
                throw new ValidationException("Event id is not setted", "");
            var Event = Database.Events.Get(EventId.Value);
            if (Event == null)
                throw new ValidationException("Event not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile,UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ClientProfile>, List<UserDTO>>(Event.Moderators);
        }

        public IEnumerable<ReportDTO> GetReports(int? EventId)
        {
            if (EventId == null)
                throw new ValidationException("Event id is not setted", "");
            var Event = Database.Events.Get(EventId.Value);
            if (Event == null)
                throw new ValidationException("Event not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Report>, List<ReportDTO>>(Event.Reports);
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Event>, List<EventDTO>>(Database.Events.GetAll());
        }

        public void Update(EventDTO eventDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
