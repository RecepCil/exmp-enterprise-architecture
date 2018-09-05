using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Customer
    {
        public string CustomerID { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }
        //public string CompanyName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }

        //public Account Account { get; set; }
    }
}
