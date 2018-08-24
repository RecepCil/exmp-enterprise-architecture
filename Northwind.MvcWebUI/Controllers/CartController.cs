using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        public CartController(IProductService productService)//IproductService'i başlatıyoruz
        {
            _productService = productService;
        }

        public RedirectToRouteResult AddToCart(int productId,Cart cart)
        {
            Product product = _productService.Get(productId);
            
            cart.AddToCart(product,1);  //ürünü sepete ekle
            return RedirectToAction("Index",cart);
        }

        public ViewResult Index(Cart cart)
        {
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(int productId,Cart cart)
        {
            Product product = _productService.Get(productId);

            cart.RemoveFromCart(product);
            
            return RedirectToAction("Index",cart);

        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid) //Gelen modelin durumu uygunsa
            {
                //Manager'dan DB'ye kayıt yapılacak

                return View("Complete");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }

    }

}