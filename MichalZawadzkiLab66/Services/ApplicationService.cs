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
        /// <summary>
        /// Pobranie takeOrderViewModel
        /// </summary>
        /// <returns></returns>
        public TakeOrderViewModel GetTakeOrderViewModel()
        {
            var pizzas = GetAllPizzas();
            var pizzasComboBox = _mappingService.MapToPizzasComboBox(pizzas);
            var takeOrderViewModel = _mappingService.MapToTakeOrderViewModel(pizzasComboBox);
            return takeOrderViewModel;
        }
        /// <summary>
        /// Dodanie zamowienia
        /// </summary>
        /// <param name="order"></param>
        /// <param name="userId"></param>
        public void AddOrder(TakeOrderViewModel order, string userId)
        {
            order.Order.UserId = Int32.Parse(userId);
            var pizza = _dataBaseService.GetPizzaById(order.Order.PizzaId);
            var orderToAdd = _mappingService.MapToOrder(order, pizza);
            _dataBaseService.AddOrder(orderToAdd);
        }
        /// <summary>
        /// Pobranie wszystkich pizz
        /// </summary>
        /// <returns></returns>
        public List<Pizza> GetAllPizzas()
        {
            return _dataBaseService.GetAllPizzas();
        }
        /// <summary>
        /// Pobranie pizzy po jej id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pizza GetPizzaById(int id)
        {
            return _dataBaseService.GetPizzaById(id);
        }
        /// <summary>
        /// Pobranie wszystkich zamowien
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            return _dataBaseService.GetAllOrders();
        }
        /// <summary>
        /// Pobranie zamowienia po jego id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(int id)
        {
            return _dataBaseService.GetOrderById(id);
        }
        /// <summary>
        /// Uaktualnienie pizzy
        /// </summary>
        /// <param name="pizza"></param>
        public void UpdatePizza(Pizza pizza)
        {
            _dataBaseService.UpdatePizza(pizza);
        }
        /// <summary>
        /// Dodanie pizzy
        /// </summary>
        /// <param name="pizza"></param>
        public void AddPizza(Pizza pizza)
        {
            _dataBaseService.AddPizza(pizza);
        }
        /// <summary>
        /// Usuniecie pizzy
        /// </summary>
        /// <param name="id"></param>
        public void RemovePizzaById(int id)
        {
            _dataBaseService.RemovePizzaById(id);
        }
        /// <summary>
        /// Pobranie usera po jego emailu
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            var user = _dataBaseService.GetUserByEmail(email);
            return user;
        }
        /// <summary>
        /// Pobranie kierowcy po jego emailu
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Driver GetDriverByEmail(string email)
        {
            var driver = _dataBaseService.GetDriverByEmail(email);
            return driver;
        }
        /// <summary>
        /// Utworzenie usera
        /// </summary>
        /// <param name="model"></param>
        public void CreateUser(RegisterModel model)
        {
            var user = _mappingService.MapToUser(model);
            _dataBaseService.AddUser(user);
        }
        /// <summary>
        /// Zmiana statusu zamowienia
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        public void ChangeOrderStatus(string orderId, Status status)
        {
            var id = Int32.Parse(orderId);
            var order = GetOrderById(id);
            order.Status = status;
            _dataBaseService.UpdateOrder(order);
        }
        /// <summary>
        /// Pobranie zamowien jednego uzytkownika po jego id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrdersByUserId(string id)
        {
            var userId = Int32.Parse(id);
            var userOrders = _dataBaseService.GetOrdersByUserId(userId);
            return userOrders;
        }
    }
}