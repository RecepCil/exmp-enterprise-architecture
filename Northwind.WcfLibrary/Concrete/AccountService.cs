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
    public class AccountService : IAccountService
    {
        private AccountManager _accountManager = new AccountManager(new EfAccountDal());

        public void Add(Account account)
        {
            _accountManager.Add(account);
        }

        public void Delete(int accountID)
        {
            _accountManager.Delete(accountID);
        }

        public Account Get(int userID)
        {
            return _accountManager.Get(userID);
        }

        public List<Account> GetAll()
        {
            return _accountManager.GetAll();
        }

        public void Update(Account account)
        {
            _accountManager.Update(account);
        }
    }
}
