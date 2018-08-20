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

        public RedirectToRouteResult AddToCart(int productId)
        {
            Product product = _productService.Get(productId);

            //Session'ı çek  <->  Object'in addToCart'ı yok
            var cart = (Cart)Session["cart"];

            if (cart == null) //Session boşsa
            {   //yeni session oluştur
                cart = new Cart();
                Session["cart"] = cart;
            }

            //ürünü sepete ekle
            cart.AddToCart(product,1);
            return RedirectToAction("Index",cart);

        }

        public ViewResult Index()
        {
            var cart = (Cart)Session["cart"];
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(int productId)
        {
            Product product = _productService.Get(productId);

            var cart = (Cart)Session["cart"];

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

        public PartialViewResult CartSummary()
        {
            var cart = (Cart)Session["cart"];

            if(cart==null)
            {
                cart = new Cart();
            }

            return PartialView(cart);
        }

    }

}