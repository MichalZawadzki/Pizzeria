using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MichalZawadzkiLab66.Models;
using Microsoft.Owin.Security;

namespace MichalZawadzkiLab66.Services
{
    public interface IAuthenticationService
    {
        ClaimsIdentity CreateUserIdentity(User user);
        ClaimsIdentity CreateDriverIdentity(Driver driver);
        void SignIn(ClaimsIdentity identity, HttpRequestBase request);
        IAuthenticationManager GetAuthManager(HttpRequestBase request);
        void SignOut(HttpRequestBase request);
        string GetUserIdFromRequest(HttpRequestBase request);
    }
}
