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
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAll();

        [OperationContract]
        Customer Get(string customerID);

        [OperationContract]
        void Add(Customer customer);

        [OperationContract]
        void Delete(string customerID);

        [OperationContract]
        void Update(Customer customer);

    }
}
