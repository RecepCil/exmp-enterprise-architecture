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
    public class AuthenticaticationService : IAuthenticationService
    {
        /*Normalde constructor ile gelmesi lazım fakat
        SOA standartlarında servis tabanlı uygulama standartlarında
        bir sınıfın bir servisin constructor'ı olamaz
        Fakat WCF instance provider ile yine constroctur'lı olarak çekebiliyoruz(ezebiliyoruz)
        */

        AuthenticationManager _authenticaticationManager = new AuthenticationManager(new EfAuthenticationDal());

        public User Authenticate(User user)
        {
            return _authenticaticationManager.Authenticate(user);
        }
    }
}
