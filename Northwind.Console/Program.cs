using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            EfAccountDal efAccountDal = new EfAccountDal();

            NorthwindContext northwindContext = new NorthwindContext();

            //Order order = new Order();
            //order.CustomerID = "DENEM";
            //order.OrderDate = DateTime.Now;
            //order.OrderID = 1;
            //order.ShipCity = "Istanbul";
            //order.ShipCountry = "Turkey";
            //northwindContext.Orders.Add(order);

            Account account = new Account();
            account.AccountID = 1;
            account.CustomerID = "VINET";
            account.Email = "r.cil@hotmail.com";
            account.Pass = "goodgirl";

            efAccountDal.Add(account);

            

        }
    }
}
