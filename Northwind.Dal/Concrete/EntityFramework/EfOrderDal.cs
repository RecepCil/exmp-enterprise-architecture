using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfOrderDal : IOrderDal
    {
        private NorthwindContext _northwindContext = new NorthwindContext();

        public void Add(Order order)
        {
            _northwindContext.Orders.Add(order);
            _northwindContext.SaveChanges();
        }

        public void Delete(int orderID)
        {
            Order order = _northwindContext.Orders.Find(orderID);
            _northwindContext.Orders.Remove(order);
            _northwindContext.SaveChanges();
        }

        public Order Get(int orderID)
        {
            return _northwindContext.Orders.Find(orderID);
        }

        public List<Order> GetAll()
        {
            return _northwindContext.Orders.ToList();
        }

        public void Update(Order order)
        {
            Order orderToUpdate = _northwindContext.Orders.FirstOrDefault(o=>o.OrderID==order.OrderID);
            orderToUpdate.CustomerID =order.CustomerID;
            orderToUpdate.OrderDate = order.OrderDate;
            orderToUpdate.ShipCity = order.ShipCity;
            orderToUpdate.ShipCountry = order.ShipCountry;

            _northwindContext.SaveChanges();

        }
    }
}
