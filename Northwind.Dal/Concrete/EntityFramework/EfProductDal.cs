using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            Product product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Get(int productId)
        {
            //return _context.Products.Find(productId);
            return _context.Products.FirstOrDefault(x=>x.ProductID==productId);
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include("Category").ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(p=>p.ProductID==product.ProductID);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryID=product.CategoryID;
            productToUpdate.UnitPrice=product.UnitPrice;
        //    productToUpdate.UnitsInStock=product.UnitsInStock;

            _context.SaveChanges();
        }
    }
}
