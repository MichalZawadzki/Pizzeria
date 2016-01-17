using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    public class PizzaStoreDbInitializer : DropCreateDatabaseAlways<PizzaStoreDbContext>
    {
        protected override void Seed(PizzaStoreDbContext context)
        {
            List<Pizza> pizzas = new List<Pizza>()
            {
                new Pizza(){Name = "Wiejska", Price = 12.5f,  Components = "salami, ser"},
                new Pizza(){Name = "Salami", Price = 13.5f, Components = "oliwki, ser"},
                new Pizza(){Name = "Hawajska", Price = 22.5f, Components = "ser feta, szynka, ser"},
                new Pizza(){Name = "Calzone", Price = 14.5f, Components = "szynka, ananas, salami, ser"}
            };

            List<Order> orders = new List<Order>()
            {
                new Order(){Address = "Kazimierska 27/3", Date = DateTime.Now, Name = "Michał", PhoneNumber = "123123123", Surname = "Zawadzki", PizzaId = 2, Pizza = pizzas[2], Status = Status.Zamowiona},
                new Order(){Address = "Zaporoska 27", Date = new DateTime(2016, 1, 17, 15, 22, 11), Name = "Jacek", PhoneNumber = "123333222", Surname = "Furtka", PizzaId = 3, Pizza = pizzas[3], Status = Status.Jedzie},
                new Order(){Address = "Mickiewicza 3", Date = new DateTime(2016, 1, 17, 16, 12, 11), Name = "Kasia", PhoneNumber = "222322322", Surname = "Cyc", PizzaId = 1, Pizza = pizzas[1], Status = Status.Dostarczona}
            };
            User user = new User(){Email = "u@u.pl", Name = "u", Password = "u"};
            Driver driver = new Driver() { Email = "d@d.pl", Name = "d", Password = "d" };
            context.Drivers.Add(driver);
            context.Users.Add(user);
            context.Pizzas.AddRange(pizzas);
            context.Orders.AddRange(orders);
            
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}