using Abc.Core.Entities;

namespace Abc.Northwind.Entites.Concreate
{
    public class Category :IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
