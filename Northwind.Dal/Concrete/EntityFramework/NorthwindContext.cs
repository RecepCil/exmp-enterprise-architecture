using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
