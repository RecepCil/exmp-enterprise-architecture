using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Entities;


namespace Northwind.Dal.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();

        Product Get(int productId);

        void Add(Product product);
        void Delete(int productId);
        void Update(Product product);

    }
}
