using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    /// <summary>
    /// Czasami lubi wyrzocac blad ze nie moze dodac bazy bo plik .mdf juz istnieje, wystarczy usunac recznie plik, nie wiem jak rozwiazac ten problem
    /// </summary>
    public class PizzaStoreDbInitializer : DropCreateDatabaseAlways<PizzaStoreDbContext>
    {
        protected override void Seed(PizzaStoreDbContext context)
        {
            List<Pizza> pizzas = new List<Pizza>()
            {
                new Pizza(){Name = "Wiejska", Price = 12.5f,  Components = "salami, ser"},
                new Pizza(){Name = "Salami", Price = 13.5f, Components = "oliwki, ser"},
                new Pizza(){Name = "Hawajska", Price = 22.5f, Components = "ser feta, szynka, ser"},
                new Pizza(){Name = "Calzone", Price = 13.5f, Components = "szynka, ananas, salami, ser"},
                new Pizza(){Name = "Margarita", Price = 10.5f, Components = "ciasto, ser"},
                new Pizza(){Name = "Zemsta teściowej", Price = 18.5f, Components = "ciasto, ser, chili, ostra papryka"}
            };
            List<User> users = new List<User>()
            {
                new User(){Email = "u1@u.pl", Name = "Michal", Password = "u"},
                new User(){Email = "u2@u.pl", Name = "Kasia", Password = "u"},
                new User(){Email = "u3@u.pl", Name = "Maciek", Password = "u"}
            };
            
            List<Order> orders = new List<Order>()
            {
                new Order(){UserId = 1, User = users[0], Address = "Kazimierska 27/3", Date = DateTime.Now, PhoneNumber = "123123123", PizzaId = 2, Pizza = pizzas[1], Status = Status.Zamowiona},
                new Order(){UserId = 2, User = users[1], Address = "Zaporoska 27", Date = new DateTime(2016, 1, 17, 15, 22, 11), PhoneNumber = "123333222", PizzaId = 3, Pizza = pizzas[2], Status = Status.Jedzie},
                new Order(){UserId = 3, User = users[2], Address = "Mickiewicza 3", Date = new DateTime(2016, 1, 27, 16, 12, 11), PhoneNumber = "222322322", PizzaId = 1, Pizza = pizzas[0], Status = Status.Zamowiona},
                new Order(){UserId = 1, User = users[0], Address = "Kazimierska 27/3", Date = DateTime.Now, PhoneNumber = "123123123", PizzaId = 2, Pizza = pizzas[2], Status = Status.Zamowiona},
                new Order(){UserId = 2, User = users[1], Address = "Zaporoska 27", Date = new DateTime(2016, 1, 18, 11, 52, 11), PhoneNumber = "123333222", PizzaId = 2, Pizza = pizzas[1], Status = Status.Jedzie},
                new Order(){UserId = 3, User = users[2], Address = "Mickiewicza 3", Date = new DateTime(2016, 1, 17, 16, 12, 11), PhoneNumber = "222322322", PizzaId = 4, Pizza = pizzas[3], Status = Status.Jedzie},
                new Order(){UserId = 1, User = users[0], Address = "Kazimierska 27/3", Date = DateTime.Now, PhoneNumber = "123123123", PizzaId = 5, Pizza = pizzas[4], Status = Status.Zamowiona},
                new Order(){UserId = 2, User = users[1], Address = "Zaporoska 27", Date = new DateTime(2016, 1, 17, 14, 32, 11), PhoneNumber = "123333222", PizzaId = 1, Pizza = pizzas[0], Status = Status.Jedzie},
                new Order(){UserId = 3, User = users[2], Address = "Mickiewicza 3", Date = new DateTime(2016, 1, 12, 16, 12, 11), PhoneNumber = "222322322", PizzaId = 2, Pizza = pizzas[1], Status = Status.Dostarczona}
            };
            
            Driver driver = new Driver() { Email = "d@d.pl", Name = "d", Password = "d" };
            context.Drivers.Add(driver);
            context.Users.AddRange(users);
            context.Pizzas.AddRange(pizzas);
            context.Orders.AddRange(orders);
            
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}