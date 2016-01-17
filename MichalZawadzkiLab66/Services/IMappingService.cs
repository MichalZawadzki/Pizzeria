using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;

namespace MichalZawadzkiLab66.Services
{
    public interface IMappingService
    {
        Order MapToOrder(TakeOrderViewModel orderViewModel, Pizza pizza);
        List<SelectListItem> MapToPizzasComboBox(List<Pizza> pizzas);
        TakeOrderViewModel MapToTakeOrderViewModel(List<SelectListItem> pizzasComboBox);
        User MapToUser(RegisterModel registerModel);
        Driver MapToDriver(RegisterModel registerModel);
    }
}
