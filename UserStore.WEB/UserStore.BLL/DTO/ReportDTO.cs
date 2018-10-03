using System;

namespace UserStore.BLL.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public bool IsModerated { get; set; }
        public DateTime DateTime { get; set; }
        public string Information { get; set; }
        public string Publisher { get; set; }
    }
}
