using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfAccountDal : IAccountDal
    {
        private NorthwindContext _northwindContext = new NorthwindContext();

        public void Add(Account account)
        {
            _northwindContext.Accounts.Add(account);
            _northwindContext.SaveChanges();
        }

        public void Delete(int accountID)
        {
            Account account = _northwindContext.Accounts.Find(accountID);
            _northwindContext.Accounts.Remove(account);
            _northwindContext.SaveChanges();
        }

        public Account Get(int userID)
        {
            return _northwindContext.Accounts.Find(userID);
        }

        public List<Account> GetAll()
        {
            return _northwindContext.Accounts.Include("Customer").ToList();
        }

        public void Update(Account account)
        {
            Account accountToUpdate = _northwindContext.Accounts.FirstOrDefault(x=>x.AccountID == account.AccountID);
            //userToUpdate.CustomerID = user.CustomerID;
            accountToUpdate.Email = account.Email;
            accountToUpdate.Pass = account.Pass;
            _northwindContext.SaveChanges();
        }
    }
}
