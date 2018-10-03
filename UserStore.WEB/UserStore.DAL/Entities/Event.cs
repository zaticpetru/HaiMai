using System;
using System.Collections.Generic;

namespace UserStore.DAL.Entities
{
    public class Event
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
