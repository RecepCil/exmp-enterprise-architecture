using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Entities;

namespace Northwind.Dal.Abstract
{
    public interface IAuthenticationDal
    {
        Account Authenticate(Account account);

        Account CustomerLogingIn(Account account);
        Account CustomerSigningUp(Account account,Customer customer);
    }
}
