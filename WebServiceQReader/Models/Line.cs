using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceQReader.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string SubMachine { get; set; }
        public string Comment { get; set; }
    }
}