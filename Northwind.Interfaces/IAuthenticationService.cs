using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Interfaces
{
    [ServiceContract]  //Wcf Servisi olarak hizmete sun
    public interface IAuthenticationService
    {
        [OperationContract]  //Bunu da hizmete aç
        Account Authenticate(Account account);

        [OperationContract]  
        Account CustomerLogingIn(Account account);
        [OperationContract]  
        Account CustomerSigningUp(Account account,Customer customer);

    }
}
