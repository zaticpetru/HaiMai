using System;

namespace UserStore.DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public bool IsModerated { get; set; }
        public DateTime DateTime { get; set; }
        public string Information { get; set; }
        public string Publisher { get; set; }
    }
}
