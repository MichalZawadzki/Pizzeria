using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;

namespace MichalZawadzkiLab66.Controllers
{
    public class PizzaController : Controller
    {
        private IApplicationService _applicationService;

        public PizzaController()
        {
            _applicationService = new ApplicationService();
        }

        [HttpGet]
        public ActionResult ManagePizzas()
        {
            var pizzas = _applicationService.GetAllPizzas();
            return View(pizzas);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Pizza());
        }

        [HttpPost]
        public ActionResult Edit(Pizza pizza)
        {
            _applicationService.UpdatePizza(pizza);
            return RedirectToAction("ManagePizzas");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pizza = _applicationService.GetPizzaById(id);
            return View(pizza);
        }

        [HttpPost]
        public ActionResult Add(Pizza pizza)
        {
            _applicationService.AddPizza(pizza);
            return RedirectToAction("ManagePizzas");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _applicationService.RemovePizzaById(id);
            return RedirectToAction("ManagePizzas");
        }
    }
}