using System;
using System.Collections.Generic;
using System.Text;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.Business.Apstract
{
   public interface IProductService 
    {
        //Backendin çıkış noktasıdır. Repository deseni veri erişim katmanında kullanılması gerekir.

        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Upadte(Product product);
        void Delete(int productId);
    }
}
