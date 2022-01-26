using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuraliWeb.Models
{
    public class ViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<SubSubCategory> SubSubCategories { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}