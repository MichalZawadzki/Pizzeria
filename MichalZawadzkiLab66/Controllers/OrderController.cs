using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;
using Microsoft.AspNet.Identity;

namespace MichalZawadzkiLab66.Controllers
{
    public class OrderController : Controller
    {
        private IApplicationService _applicationService;
        private IAuthenticationService _authenticationService;
        public OrderController()
        {
            _applicationService = new ApplicationService();
            _authenticationService = new AuthenticationService();
        }

        [HttpGet]
        public ActionResult OrderList()
        {
            var userId = _authenticationService.GetUserIdFromRequest(Request);
            var orders = _applicationService.GetOrdersByUserId(userId);
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
            var userId = _authenticationService.GetUserIdFromRequest(Request);
            _applicationService.AddOrder(orderViewModel, userId);
            var orders = _applicationService.GetOrdersByUserId(userId);
            return View("OrderList", orders);
        }

        [HttpGet]
        public ActionResult DriverOrderList()
        {
            var orders = _applicationService.GetAllOrders();
            return View(orders);
        }
        /// <summary>
        /// Niestety czasami dwie ponizsze metody nie dostaja odpowiedniego id, wiec zmieniaja statusy zlych zamowien, nie wiem gdzie blad
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
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