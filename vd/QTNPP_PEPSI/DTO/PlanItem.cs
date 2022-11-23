using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PlanItem
    {
        private DateTime date;
        private string job;
        private Point fromTime;
        private Point toTime;
        private string status;

        public DateTime Date { get => date; set => date = value; }
        public string Job { get => job; set => job = value; }
        public Point FromTime { get => fromTime; set => fromTime = value; }
        public Point ToTime { get => toTime; set => toTime = value; }
        public string Status { get => status; set => status = value; }

        public static List<string> ListStatus = new List<string>() { "DONE", "DOING", "COMING", "MISSED" };
    }

    public enum EPlanItem
    { 
        DONE, DOING, COMING, MISSED
    }
}
