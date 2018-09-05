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
    public class OrderDetailService : IOrderDetailService
    {
        private OrderDetailManager _orderDetailManager = new OrderDetailManager(new EfOrderDetailDal());

        public void Add(OrderDetail orderDetail)
        {
            _orderDetailManager.Add(orderDetail);
        }

        public void Delete(int orderId, int productId)
        {
            _orderDetailManager.Delete(orderId,productId);
        }

        public OrderDetail Get(int orderId, int productId)
        {
            return _orderDetailManager.Get(orderId,productId);
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailManager.GetAll();
        }

        public void Update(OrderDetail orderDetail)
        {
            _orderDetailManager.Update(orderDetail);
        }
    }
}
