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

        public User Authenticate(User user)
        {
            return _authenticationDal.Authenticate(user);
        }
    }
}
