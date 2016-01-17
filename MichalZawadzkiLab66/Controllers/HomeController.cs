using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;

namespace MichalZawadzkiLab66.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationService _applicationService;
        public HomeController()
        {
            _applicationService = new ApplicationService();
        }

        public ActionResult Index()
        {
            var pizzas = _applicationService.GetAllPizzas();
            return View(pizzas);
        }
    }
}