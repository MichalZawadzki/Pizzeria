using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using MichalZawadzkiLab66.Models;

namespace MichalZawadzkiLab66.Services
{
    public class DataBaseService : IDataBaseService
    {
        private PizzaStoreDbContext context;

        public DataBaseService()
        {
            context = new PizzaStoreDbContext();
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public List<Pizza> GetAllPizzas()
        {
            var pizzas = context.Pizzas.ToList();
            return pizzas;
        }

        public Pizza GetPizzaById(int id)
        {
            var pizza = context.Pizzas.Find(id);
            return pizza;
        }

        public List<Order> GetAllOrders()
        {
            var orders = context.Orders.ToList();
            return orders;
        }

        public Order GetOrderById(int id)
        {
            var order = context.Orders.Find(id);
            return order;
        }

        public void UpdatePizza(Pizza pizza)
        {
            context.Pizzas.AddOrUpdate(pizza);
            context.SaveChanges();
        }

        public void AddPizza(Pizza pizza)
        {
            context.Pizzas.Add(pizza);
            context.SaveChanges();
        }

        public void RemovePizzaByPizza(Pizza pizza)
        {
            context.Pizzas.Remove(pizza);
            context.SaveChanges();
        }

        public void RemovePizzaById(int id)
        {
            Pizza pizzaToDelete = GetPizzaById(id);
            context.Pizzas.Remove(pizzaToDelete);
            context.SaveChanges();
        }


        public User GetUserByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public Driver GetDriverByEmail(string email)
        {
            var driver = context.Drivers.FirstOrDefault(d => d.Email == email);
            return driver;
        }
        
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddDriver(Driver driver)
        {
            context.Drivers.Add(driver);
            context.SaveChanges();
        }


        public void UpdateOrder(Order order)
        {
            context.Orders.AddOrUpdate(order);
            context.SaveChanges();
        }
    }
}