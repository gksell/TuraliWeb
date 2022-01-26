using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TuraliWeb.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

    }
}