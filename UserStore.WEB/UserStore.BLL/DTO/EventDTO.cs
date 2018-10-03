using System;
using System.Collections.Generic;
using UserStore.DAL.Entities;

namespace UserStore.BLL.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public ClientProfile Admin { get; set; }
        public ICollection<ClientProfile> Moderators { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
