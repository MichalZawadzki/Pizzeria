using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    public class PizzaStoreDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public PizzaStoreDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<PizzaStoreDbContext>(new PizzaStoreDbInitializer());
        }
    }
}