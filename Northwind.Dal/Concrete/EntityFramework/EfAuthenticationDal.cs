using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticationDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public Account Authenticate(Account account)
        {
            //Veritabanından alınacak.
            if (account.Email == "admin" && account.Pass == "admin")
            {
                return account;
            }
            return null;
        }

        public Account CustomerLogingIn(Account account)
        {
            //This account is a customer?
            bool IsCustomer = _context.Accounts.Any(x => x.Email == account.Email);

            if (IsCustomer)
            {
                Account accountToLogingIn = _context.Accounts.FirstOrDefault(x => x.Email == account.Email);

                if (accountToLogingIn.Pass == account.Pass)
                {
                    //Success
                    return accountToLogingIn;
                }
            }

            //Account is not a customer
            return null;
        }

        public Account CustomerSigningUp(Account account, Customer customer)
        {
            bool IsExist; string customerID;

            //Get an unique CustomerID
            do
            {   //type of customerID is nchar(5) and I need to provide it random CustomerID. I need a little trick
                customerID = "R" + (new Random().Next(1000, 9999)).ToString();

                IsExist = _context.Customers.Any(x => x.CustomerID == customerID);
            } while (IsExist);

            //Eşittir burası
            customer.CustomerID = customerID;
            customer.CompanyName = "Null";
            account.CustomerID = customerID;

            _context.Customers.Add(customer);
            _context.Accounts.Add(account);

            _context.SaveChanges();

            return account;
        }
    }
}
