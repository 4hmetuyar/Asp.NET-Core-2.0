using System;
using System.Collections.Generic;
using Abc.Northwind.Business.Apstract;
using Abc.Northwind.DataAccess.Apstract;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private ICategorytDal _categorytDal;

        public CategoryManager(ICategorytDal categorytDal)
        {
            _categorytDal = categorytDal;
        }

        public List<Category> GetAll()
        {
           return _categorytDal.GetList();
        }
    }
}