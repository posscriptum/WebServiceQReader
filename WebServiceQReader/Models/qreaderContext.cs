using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServiceQReader.Models
{
    public class qreaderContext : DbContext
    {
        public qreaderContext() : base("qreaderdb") {}
        public virtual DbSet<Checkpoint> Checkpoints { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
    }
}