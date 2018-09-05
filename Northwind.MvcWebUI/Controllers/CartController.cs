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
        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;

        //IproductService'i başlatıyoruz
        public CartController(IProductService productService, ICustomerService customerService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public RedirectToRouteResult AddToCart(int productId, Cart cart)
        {
            Product product = _productService.Get(productId);

            cart.AddToCart(product, 1);  //ürünü sepete ekle
            return RedirectToAction("Index", cart);
        }

        public ViewResult Index(Cart cart)
        {
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(int productId, Cart cart)
        {
            Product product = _productService.Get(productId);

            cart.RemoveFromCart(product);

            return RedirectToAction("Index", cart);

        }

        [HttpGet]
        public ActionResult Checkout()
        {
            try
            {
                ViewBag.Account = (Account)Session["Account"];
                ViewBag.Customer = _customerService.Get(ViewBag.Account.CustomerID);
            }
            catch { }
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails,Cart cart)
        {
            //Customer ve Account'u getir
            Account account = (Account)Session["account"];
            Customer customer = new Customer();

            bool IsAuthenticate = (account == null);
            if (account != null)
            {
                customer = _customerService.Get(account.CustomerID);
                IsAuthenticate = true;
            }

            if (ModelState.IsValid) //Gelen modelin durumu uygunsa
            {
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.ShipCity = shippingDetails.City;
                order.ShipCountry = shippingDetails.Country;

                if (IsAuthenticate)
                {
                    order.CustomerID = customer.CustomerID;

                }

                _orderService.Add(order);

                foreach (var item in cart.Lines)
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderID = order.OrderID;
                    //orderDetail.Order = order; çoklu kaydetme hatası
                    //orderDetail.Order.OrderID = order.OrderID;  hata verdi

                    orderDetail.ProductID = item.Product.ProductID;

                    //orderDetail.Product.Category = item.Product.Category;
                    //orderDetail.Product.CategoryID = item.Product.CategoryID;
                    
                    orderDetail.UnitPrice = item.Product.UnitPrice;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Discount = 0;

                    _orderDetailService.Add(orderDetail);
                }
                return View("Complete");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            ViewBag.Account = (Account)Session["account"];
            return PartialView(cart);
        }

    }

}