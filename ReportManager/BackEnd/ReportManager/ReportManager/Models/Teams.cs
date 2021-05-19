using System.Collections.Generic;

namespace ReportManager.Models
{
    public class Teams
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Teams> ShowAllTeam { get; set; }
    }
}