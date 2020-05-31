using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceQReader.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ShiftID { get; set; }
        public int EmployeeID { get; set; }
        public int CheckpointID { get; set; }
        public bool Checked { get; set; }
        public string Comment { get; set; }
        public string Photo { get; set; }
    }
}