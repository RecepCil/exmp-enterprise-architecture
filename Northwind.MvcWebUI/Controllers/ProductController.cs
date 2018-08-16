using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
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

        public int PageSize = 5;
        public ViewResult Index(int page = 1,int category = 0)
        {                                                                   //2. durumda hepsini getir
            List<Product> products = _productService.GetAll().Where(p=>p.CategoryID==category||category==0).ToList();
            
            ProductViewModel pvm = new ProductViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count,
                    CurrentPage = page
                }
            };

            ViewBag.CurrentCategory = category;
            
            return View(pvm);
        }

        public ViewResult Indexing(int page = 1, int category = 0)
        {                                                                   //2. durumda hepsini getir
            List<Product> products = _productService.GetAll().Where(p => p.CategoryID == category || category == 0).ToList();

            ProductViewModel pvm = new ProductViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count,
                    CurrentPage = page
                }
            };

            return View(pvm);
        }


    }
}