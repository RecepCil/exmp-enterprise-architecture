using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interfaces
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        List<Account> GetAll();

        [OperationContract]
        Account Get(int accountID);

        [OperationContract]
        void Add(Account account);

        [OperationContract]
        void Delete(int accountID);

        [OperationContract]
        void Update(Account account);

    }
}
