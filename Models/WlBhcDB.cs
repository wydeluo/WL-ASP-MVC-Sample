using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WlBhcApp.Models
{
    public class WlBhcDB:DbContext
    {

        public WlBhcDB():base("name=DefaultConnection")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}