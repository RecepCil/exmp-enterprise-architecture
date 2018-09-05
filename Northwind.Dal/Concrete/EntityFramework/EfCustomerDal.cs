using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        private NorthwindContext _northwindContext = new NorthwindContext();

        public void Add(Customer customer)
        {
            _northwindContext.Customers.Add(customer);
            _northwindContext.SaveChanges();
        }

        public void Delete(string customerID)
        {
            Customer customer = _northwindContext.Customers.Find(customerID);
            _northwindContext.Customers.Remove(customer);
            _northwindContext.SaveChanges();
        }

        public Customer Get(string customerID)
        {
            try
            {
                return _northwindContext.Customers.Find(customerID); ;
            }
            catch
            {
                return null;
            }
         
        }

        public List<Customer> GetAll()
        {
            return _northwindContext.Customers.Include("Accounts").ToList();
        }

        public void Update(Customer customer)
        {
            Customer customerToUpdate = _northwindContext.Customers.FirstOrDefault(x=>x.CustomerID == customer.CustomerID);
            customerToUpdate.Address=customer.Address;
            customerToUpdate.City=customer.City;
            customerToUpdate.ContactName=customer.ContactName;
            customerToUpdate.Country=customer.Country;

            _northwindContext.SaveChanges();
        }
    }
}
