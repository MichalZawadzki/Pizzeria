using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    public enum Status
    {
        Zamowiona, Jedzie, Dostarczona 
    }
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Pizza Pizza { get; set; }

        public Order()
        {
            Date = DateTime.Now;
            Status = Status.Zamowiona;
        }
    }
}