using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dal.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();
    }
}
