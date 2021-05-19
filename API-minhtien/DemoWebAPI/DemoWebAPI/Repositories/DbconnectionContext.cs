using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Repositories
{
    public class DbconnectionContext : DbContext
    {
        public DbconnectionContext() : base("DefaultConnection")

        {

        }

        public DbSet<Comment> Comment { get; set; }
    }
}