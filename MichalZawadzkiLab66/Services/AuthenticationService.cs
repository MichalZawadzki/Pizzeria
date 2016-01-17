using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using MichalZawadzkiLab66.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MichalZawadzkiLab66.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Utworzenie identity uzytkownika
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public System.Security.Claims.ClaimsIdentity CreateUserIdentity(User user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Email, user.Email), 
            }, "ApplicationCookie" );
            return identity;
        }
        /// <summary>
        /// Utworzenie identity kierowcy
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public System.Security.Claims.ClaimsIdentity CreateDriverIdentity(Driver driver)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, driver.Name),
                new Claim(ClaimTypes.Sid, driver.Id.ToString()),
                new Claim(ClaimTypes.Role, "Driver"),
                new Claim(ClaimTypes.Email, driver.Email), 
            }, "ApplicationCookie");
            return identity;
        }
        /// <summary>
        /// Zalogowanie
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="request"></param>
        public void SignIn(ClaimsIdentity identity, HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignIn(identity);
        }
        /// <summary>
        /// Pobranie authentification managera
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IAuthenticationManager GetAuthManager(HttpRequestBase request)
        {
            var context = request.GetOwinContext();
            return context.Authentication;
        }
        /// <summary>
        /// Wylogowanie sie
        /// </summary>
        /// <param name="request"></param>
        public void SignOut(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignOut("ApplicationCookie");
        }
        /// <summary>
        /// Pobranie id urzytkownika po requescie
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetUserIdFromRequest(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            var claim = authManager.User.Claims.SingleOrDefault(r => r.Type == ClaimTypes.Sid);
            return claim.Value;
        }
    }
}