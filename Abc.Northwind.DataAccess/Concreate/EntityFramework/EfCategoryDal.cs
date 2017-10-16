using Abc.Core.Entities.EntityFramework;
using Abc.Northwind.DataAccess.Apstract;
using Abc.Northwind.Entites.Concreate;

namespace Abc.Northwind.DataAccess.Concreate.EntityFramework
{
    public  class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext> ,ICategorytDal
    {
    }
}