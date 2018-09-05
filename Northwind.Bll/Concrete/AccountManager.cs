using Northwind.Dal.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Bll.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public void Add(Account account)
        {
            _accountDal.Add(account);
        }

        public void Delete(int accountID)
        {
            _accountDal.Delete(accountID);
        }

        public Account Get(int accountID)
        {
            return _accountDal.Get(accountID);
        }

        public List<Account> GetAll()
        {
            return _accountDal.GetAll();
        }

        public void Update(Account account)
        {
            _accountDal.Update(account);
        }
    }
}
