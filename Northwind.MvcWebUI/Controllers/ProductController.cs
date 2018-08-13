using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager = new ProductManager(new EfProductDal());    yerine

        private IProductService _productService;
        public ProductController(IProductService productService)   //Bll veya WcfLibrary, atamasını infrastructure folder içinde yapıyoruz
        {
            _productService = productService;
        }

        public ViewResult Index()
        {
            var list = _productService.GetAll();
            return View(list);
        }
    }
}