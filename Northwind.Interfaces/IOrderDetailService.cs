using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interfaces
{
    [ServiceContract]
    public interface IOrderDetailService
    {
        [OperationContract] 
        List<OrderDetail> GetAll();

        [OperationContract]
        OrderDetail Get(int orderId,int productId);

        [OperationContract]
        void Add(OrderDetail orderDetail);

        [OperationContract]
        void Delete(int orderId, int productId);

        [OperationContract]
        void Update(OrderDetail orderDetail);
    }
}
