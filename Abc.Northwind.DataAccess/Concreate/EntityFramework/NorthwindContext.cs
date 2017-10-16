using System;
using System.Collections.Generic;
using System.Text;
using Abc.Northwind.Entites.Concreate;
using Microsoft.EntityFrameworkCore;

namespace Abc.Northwind.DataAccess.Concreate.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind; Trushed_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
