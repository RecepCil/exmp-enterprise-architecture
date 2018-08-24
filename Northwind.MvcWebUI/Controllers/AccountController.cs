using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            User validatedUser = _authenticationService.Authenticate(user);

            if (validatedUser == null)
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı.");
            }

            if (ModelState.IsValid)
            {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return Redirect(returnUrl);
            }
            return View();
        }
    }
}