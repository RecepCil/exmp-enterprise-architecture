using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            List<Product> products = _productService.GetAll();

            return View(products);
        }
        
        public ActionResult CreateNew()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View(new Product());
        }

        [HttpPost]
        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [Authorize]
        public ActionResult Edit(int productId)
        {
            ViewBag.Categories = _categoryService.GetAll();
            Product product = _productService.Get(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit",new { productId = product.ProductID });
        }

        [Authorize]
        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }

    }
}