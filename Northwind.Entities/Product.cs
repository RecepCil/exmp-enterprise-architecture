using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public Int32 UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}
