using System;
using System.Collections.Generic;
using System.Text;
using Abc.Core.Entities.EntityFramework;
using Abc.Northwind.DataAccess.Apstract;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.DataAccess.Concreate.EntityFramework
{
   public  class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContent> ,IProductDal
    {
        //Autofact gibi container tanımlamak için oluşturduk.
    }
}
