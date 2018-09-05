using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface IOrderDetailDal
    {
        List<OrderDetail> GetAll();

        OrderDetail Get(int orderId,int productId);

        void Add(OrderDetail orderDetail);
        void Delete(int orderId, int productId);
        void Update(OrderDetail orderDetail);
    }
}
