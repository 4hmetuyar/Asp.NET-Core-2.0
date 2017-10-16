using System;
using System.Collections.Generic;
using System.Text;
using Abc.Northwind.Business.Apstract;
using Abc.Northwind.DataAccess.Apstract;
using Abc.Northwind.DataAccess.Concreate.EntityFramework;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.Business.Concreate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public List<Product> GetAll()
        {
            //EfProductDal productDal  = new EfProductDal(); //Bu şekilde çalışır fakat SOLID standartlarına göre üst katman alt katmanı newleyemez. 
            ////Bu şekilde Business entity Framawork tamamen bağımlı hale gelmiş olur.
            //return productDal.GetList();


            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryId == categoryId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Upadte(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }
    }
}
