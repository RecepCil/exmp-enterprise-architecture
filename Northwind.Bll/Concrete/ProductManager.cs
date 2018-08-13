using Northwind.Dal.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Bll.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Validation-Security-Ex.Handling
            return _productDal.GetAll();
        }

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
