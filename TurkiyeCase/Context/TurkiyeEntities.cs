using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TurkiyeCase.Context
{
    public class TurkiyeEntities : DbContext
    {
        public TurkiyeEntities() : base("TurkiyeDbCon")
        {

        }
        public DbSet<Bolge> Bolges { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
    }
}