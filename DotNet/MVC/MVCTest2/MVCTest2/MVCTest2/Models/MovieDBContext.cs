using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCTest2.Models
{
    public class MovieDBContext : DbContext
    {
        public DbSet<MovieDB> Movies { get; set; } 
    }
}