using System;
using System.Collections.Generic;
using System.Text;
using Abc.Core.DataAccess;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.DataAccess.Apstract
{
    public interface IProductDal :IEntityRepository<Product>
    {
        //Custom Operation
        //Özel operasyonlar yazmak için kullanılır. Örnek olarak : IEntityRepository içinde yazılmış sorguların dışında sorgu yazmak için kullanılır. 
        //Her yerde geçerli olmayan sadece product özgü operasyonlar için yazılacak kodlar.
    }
}
