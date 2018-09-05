using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface IAccountDal
    {
        List<Account> GetAll();

        Account Get(int accountID);

        void Add(Account account);
        void Delete(int accountID);
        void Update(Account account);

    }
}
