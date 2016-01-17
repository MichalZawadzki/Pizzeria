using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MichalZawadzkiLab66.Models
{
    public class TakeOrderViewModel
    {
        public List<SelectListItem> Pizzas { get; set; }
        public Order Order { get; set; }

        public TakeOrderViewModel()
        {
            Pizzas = new List<SelectListItem>();
            Order = new Order();
        }
    }
}