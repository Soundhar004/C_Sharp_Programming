using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Assignments.Models;
using System.Data.Entity;

namespace MVC_Assignments.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}