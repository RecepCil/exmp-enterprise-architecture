using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticationDal
    {
        public User Authenticate(User user)
        {
            //Veritabanından alınacak.
            if (user.UserName == "engin" && user.Password == "1234")
            {
                return user;
            }
            return null;
        }
    }
}
