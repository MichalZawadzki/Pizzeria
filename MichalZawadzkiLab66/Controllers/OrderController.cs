using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;

namespace MichalZawadzkiLab66.Controllers
{
    public class OrderController : Controller
    {
        private IApplicationService _applicationService;
        public OrderController()
        {
            _applicationService = new ApplicationService();
        }

        [HttpGet]
        public ActionResult OrderList()
        {
            var orders = _applicationService.GetAllOrders();
            return View(orders);
        }

        [HttpGet]
        public ActionResult TakeOrder()
        {
            var takeOrderViewModel = _applicationService.GetTakeOrderViewModel();
            return View(takeOrderViewModel);
        }

        [HttpPost]
        public ActionResult TakeOrder(TakeOrderViewModel orderViewModel)
        {
            _applicationService.AddOrder(orderViewModel);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DriverOrderList()
        {
            var orders = _applicationService.GetAllOrders();
            return View(orders);
        }

        [HttpPost]
        public ActionResult ChangeOrderToJedzie(string orderId)
        {
            _applicationService.ChangeOrderStatus(orderId, Status.Jedzie);
            var orders = _applicationService.GetAllOrders();
            return View("DriverOrderList", orders);
        }

        [HttpPost]
        public ActionResult ChangeOrderToDostarczona(string orderId)
        {
            _applicationService.ChangeOrderStatus(orderId, Status.Dostarczona);
            var orders = _applicationService.GetAllOrders();
            return View("DriverOrderList", orders);
        }
	}
}