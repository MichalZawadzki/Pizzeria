using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;

namespace MichalZawadzkiLab66.Services
{
    public class MappingService : IMappingService
    {
        /// <summary>
        /// Mapowanie takeOrderViewModel na order
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <param name="pizza"></param>
        /// <returns></returns>
        public Order MapToOrder(TakeOrderViewModel orderViewModel, Pizza pizza)
        {
            Order order = orderViewModel.Order;
            order.Pizza = pizza;
            return order;
        }
        /// <summary>
        /// Mapowanie listy pizz na list<SelectListItem>
        /// </summary>
        /// <param name="pizzas"></param>
        /// <returns></returns>
        public List<SelectListItem> MapToPizzasComboBox(List<Pizza> pizzas)
        {
            List<SelectListItem> pizzasComboBox = new List<SelectListItem>();
            foreach (var pizza in pizzas)
            {
                SelectListItem pizzaComboBox = new SelectListItem() { Value = pizza.Id.ToString(), Selected = false, Text = pizza.Name + ", " + pizza.Price };
                pizzasComboBox.Add(pizzaComboBox);
            }
            pizzasComboBox[0].Selected = true;
            return pizzasComboBox;
        }
        /// <summary>
        /// Mapowanie listy selectListItem na takeOrderViewModel
        /// </summary>
        /// <param name="pizzasComboBox"></param>
        /// <returns></returns>
        public TakeOrderViewModel MapToTakeOrderViewModel(List<SelectListItem> pizzasComboBox)
        {
            var takeOrderViewModel = new TakeOrderViewModel()
            {
                Order = new Order(), 
                Pizzas = pizzasComboBox
            };
            return takeOrderViewModel;
        }
        /// <summary>
        /// Mapowanie modelu rejestracji na model usera
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public User MapToUser(RegisterModel registerModel)
        {
            var user = new User(){Email = registerModel.Email, Name = registerModel.Name, Password = registerModel.Password};
            return user;
        }
        /// <summary>
        /// Mapowanie modelu rejestracji na model kierowcy
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public Driver MapToDriver(RegisterModel registerModel)
        {
            var driver = new Driver() { Email = registerModel.Email, Name = registerModel.Name, Password = registerModel.Password };
            return driver;
        }
    }
}