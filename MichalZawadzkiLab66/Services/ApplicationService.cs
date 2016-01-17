using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MichalZawadzkiLab66.Models;

namespace MichalZawadzkiLab66.Services
{
    public class ApplicationService : IApplicationService
    {
        IMappingService _mappingService;
        IDataBaseService _dataBaseService;

        public ApplicationService()
        {
            _mappingService = new MappingService();
            _dataBaseService = new DataBaseService();
        }

        public TakeOrderViewModel GetTakeOrderViewModel()
        {
            var pizzas = GetAllPizzas();
            var pizzasComboBox = _mappingService.MapToPizzasComboBox(pizzas);
            var takeOrderViewModel = _mappingService.MapToTakeOrderViewModel(pizzasComboBox);
            return takeOrderViewModel;
        }

        public void AddOrder(TakeOrderViewModel order)
        {
            var pizza = _dataBaseService.GetPizzaById(order.Order.PizzaId);
            var orderToAdd = _mappingService.MapToOrder(order, pizza);
            _dataBaseService.AddOrder(orderToAdd);
        }

        public List<Pizza> GetAllPizzas()
        {
            return _dataBaseService.GetAllPizzas();
        }

        public Pizza GetPizzaById(int id)
        {
            return _dataBaseService.GetPizzaById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _dataBaseService.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _dataBaseService.GetOrderById(id);
        }

        public void UpdatePizza(Pizza pizza)
        {
            _dataBaseService.UpdatePizza(pizza);
        }

        public void AddPizza(Pizza pizza)
        {
            _dataBaseService.AddPizza(pizza);
        }

        public void RemovePizzaById(int id)
        {
            _dataBaseService.RemovePizzaById(id);
        }


        public User GetUserByEmail(string email)
        {
            var user = _dataBaseService.GetUserByEmail(email);
            return user;
        }

        public Driver GetDriverByEmail(string email)
        {
            var driver = _dataBaseService.GetDriverByEmail(email);
            return driver;
        }


        public void CreateUser(RegisterModel model)
        {
            var user = _mappingService.MapToUser(model);
            _dataBaseService.AddUser(user);
        }
    }
}