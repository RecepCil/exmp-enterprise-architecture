using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface ICustomerDal
    {
        List<Customer> GetAll();

        Customer Get(string customerID);
        void Add(Customer customer);
        void Delete(string customerID);
        void Update(Customer customer);
    }
}
