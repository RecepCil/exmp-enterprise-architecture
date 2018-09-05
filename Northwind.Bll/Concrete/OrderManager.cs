using Northwind.Dal.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Bll.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public void Delete(int orderId)
        {
            _orderDal.Delete(orderId);
        }

        public Order Get(int orderId)
        {
            return _orderDal.Get(orderId);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
