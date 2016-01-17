using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Components { get; set; }
        public virtual List<Order> Orders {get; set; }
    }
}