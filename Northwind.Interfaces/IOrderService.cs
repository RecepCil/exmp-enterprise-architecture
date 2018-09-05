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
    public interface IOrderService
    {
        [OperationContract] 
        List<Order> GetAll();

        [OperationContract]
        Order Get(int orderId);

        [OperationContract]
        void Add(Order order);

        [OperationContract]
        void Delete(int orderId);

        [OperationContract]
        void Update(Order order);
    }
}
