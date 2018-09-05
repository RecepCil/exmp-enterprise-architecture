using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfLibrary.Concrete
{
    public class OrderService : IOrderService
    {
        private OrderManager _orderManager = new OrderManager(new EfOrderDal());

        public void Add(Order order)
        {
            _orderManager.Add(order);
        }

        public void Delete(int orderId)
        {
            _orderManager.Delete(orderId);
        }

        public Order Get(int orderId)
        {
            return _orderManager.Get(orderId);
        }

        public List<Order> GetAll()
        {
            return _orderManager.GetAll();
        }

        public void Update(Order order)
        {
            _orderManager.Update(order);
        }
    }
}
