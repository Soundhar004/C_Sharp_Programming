using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Coding_Challenge_10_Q1.Models;

namespace Coding_Challenge_10_Q1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public AppDbContext() : base("name=DefaultConnection")
        {
            // This constructor uses the connection string from Web.config
        }
    }
}