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
        private ICustomerService _customerService;
        private IAccountService _accountService;

        public AccountController(IAuthenticationService authenticationService, ICustomerService customerService, IAccountService accountService)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
            _accountService = accountService;
        }

        public ActionResult AdminLogin()
        {
            return View(new Account());
        }

        [HttpPost]
        public ActionResult AdminLogin(Account account, string returnUrl)
        {
            Account validatedAccount = _authenticationService.Authenticate(account);

            if (validatedAccount == null)
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı.");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(account.Email, false);

                Session["account"] = validatedAccount;

                return Redirect(returnUrl);
            }

            return View();
        }

        public ActionResult Login()
        {
            return View(new Account());
        }

        [HttpPost]                          
        public ActionResult Login(Account account, string returnUrl)
        {
            Account validatedAccount = _authenticationService.CustomerLogingIn(account);

            if (validatedAccount == null)
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı.");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(account.Email, false);

                Session["account"] = validatedAccount;

                //return Redirect(returnUrl);
                return RedirectToAction("Index", "Product");
            }
            else return View();
        }

        public ActionResult SignUp()
        {
            return View(new Account());
        }

        [HttpPost]
        public ActionResult SignUp(Customer customer, Account account)
        {
            Account newAccount = _authenticationService.CustomerSigningUp(account, customer);
            Session["account"] = newAccount;
            return RedirectToAction("Index","Product");
        }

    }
}