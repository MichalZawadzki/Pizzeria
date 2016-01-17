using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using MichalZawadzkiLab66.Models;
using Microsoft.Owin.Security;

namespace MichalZawadzkiLab66.Services
{
    public class AuthenticationService : IAuthenticationService
    {

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


        public void SignIn(ClaimsIdentity identity, HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignIn(identity);
        }

        public IAuthenticationManager GetAuthManager(HttpRequestBase request)
        {
            var context = request.GetOwinContext();
            return context.Authentication;
        }

        public void SignOut(HttpRequestBase request)
        {
            var authManager = GetAuthManager(request);
            authManager.SignOut("ApplicationCookie");
        }
    }
}