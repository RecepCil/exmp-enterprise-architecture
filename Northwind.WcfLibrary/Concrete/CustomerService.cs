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
    public class CustomerService : ICustomerService
    {
        private CustomerManager _customerManager = new CustomerManager(new EfCustomerDal());

        public void Add(Customer customer)
        {
            _customerManager.Add(customer);
        }

        public void Delete(string customerID)
        {
            _customerManager.Delete(customerID);
        }

        public Customer Get(string customerID)
        {
            return _customerManager.Get(customerID);
        }

        public List<Customer> GetAll()
        {
            return _customerManager.GetAll();
        }

        public void Update(Customer customer)
        {
            _customerManager.Update(customer);
        }
    }
}
