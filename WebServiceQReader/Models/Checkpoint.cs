using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceQReader.Models
{
    public class Checkpoint
    {
        public int Id { get; set; }
        public int LineNumberID { get; set; }
        public string CheckpointName { get; set; }
        public string Description { get; set; }
    }
}