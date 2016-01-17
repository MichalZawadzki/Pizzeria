using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichalZawadzkiLab66.Models;

namespace MichalZawadzkiLab66.Services
{
    public interface IDataBaseService
    {
        void AddOrder(Order order);
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void UpdatePizza(Pizza pizza);
        void AddPizza(Pizza pizza);
        void RemovePizzaByPizza(Pizza pizza);
        void RemovePizzaById(int id);
    }
}
