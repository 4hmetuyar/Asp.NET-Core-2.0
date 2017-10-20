using System.Collections.Generic;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.Business.Apstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}