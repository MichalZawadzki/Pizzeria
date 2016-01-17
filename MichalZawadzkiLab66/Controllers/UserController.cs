using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichalZawadzkiLab66.Models;
using MichalZawadzkiLab66.Services;

namespace MichalZawadzkiLab66.Controllers
{
    public class UserController : Controller
    {
        private IApplicationService _applicationService;
        private IAuthenticationService _authenticationService;

        public UserController()
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
            var user = _applicationService.GetUserByEmail(model.Email);
            if (user == null)
            {
                AddWrongEmailPasswordError();
                return View(model);
            }

            if (model.Password == user.Password)
            {
                var identity = _authenticationService.CreateUserIdentity(user);
                _authenticationService.SignIn(identity, Request);
                
                return RedirectToAction("Index", "Home");
            }
            AddWrongEmailPasswordError();
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _applicationService.GetUserByEmail(model.Email);
            if (user != null)
            {
                AddDuplicatedEmailError();
                return View(model);
            }
            _applicationService.CreateUser(model);
            return RedirectToAction("Index", "Home");
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