using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface IOrderDal
    {
        List<Order> GetAll();

        Order Get(int orderID);

        void Add(Order order);
        void Delete(int orderID);
        void Update(Order order);
    }
}
