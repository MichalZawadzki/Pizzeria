using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;

namespace MichalZawadzkiLab66.Controllers
{
    public class DriverController : Controller
    {
        private IApplicationService _applicationService;
        private IAuthenticationService _authenticationService;

        public DriverController()
        {
            _applicationService = new ApplicationService();
            _authenticationService = new AuthenticationService();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var driver = _applicationService.GetDriverByEmail(model.Email);
            if (driver == null)
            {
                AddWrongEmailPasswordError();
                return View(model);
            }

            if (model.Password == driver.Password)
            {
                var identity = _authenticationService.CreateDriverIdentity(driver);
                _authenticationService.SignIn(identity, Request);
                
                return RedirectToAction("Index", "Home");
            }
            AddWrongEmailPasswordError();
            return View(model);
        }

        
        [HttpPost]
        public ActionResult Logout()
        {
            _authenticationService.SignOut(Request);
            return RedirectToAction("Index", "Home");
        }
        
        public void AddWrongEmailPasswordError()
        {
            ModelState.AddModelError("Email", "Zły email lub hasło");
        }

        public void AddDuplicatedEmailError()
        {
            ModelState.AddModelError("Email", "Taki użytkownik juz istnieje");
        }
	}
}