using Northwind.Dal.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Bll.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;

        public AuthenticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }

        public Account Authenticate(Account account)
        {
            return _authenticationDal.Authenticate(account);
        }

        public Account CustomerLogingIn(Account account)
        {
            return _authenticationDal.CustomerLogingIn(account);
        }

        public Account CustomerSigningUp(Account account,Customer customer)
        {
            return _authenticationDal.CustomerSigningUp(account,customer);
        }
    }
}
