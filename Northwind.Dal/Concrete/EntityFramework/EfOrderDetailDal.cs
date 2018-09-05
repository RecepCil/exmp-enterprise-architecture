using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfOrderDetailDal : IOrderDetailDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public void Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void Delete(int orderId, int productId)
        {
            OrderDetail orderDetail = _context.OrderDetails.FirstOrDefault(x=>x.OrderID==orderId & x.ProductID == productId );
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
        }

        public OrderDetail Get(int orderId, int productId)
        {
            return _context.OrderDetails.FirstOrDefault(x => x.OrderID == orderId & x.ProductID == productId);
        }

        public List<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
        }

        public void Update(OrderDetail orderDetail)
        {
            OrderDetail orderDetailToUpdate = _context.OrderDetails.FirstOrDefault(x => x.OrderID == orderDetail.OrderID & x.ProductID == orderDetail.ProductID);

            orderDetailToUpdate.Discount = orderDetail.Discount;
            orderDetailToUpdate.Quantity = orderDetail.Quantity;
            orderDetailToUpdate.UnitPrice = orderDetail.UnitPrice;

            _context.SaveChanges();
        }
    }
}
