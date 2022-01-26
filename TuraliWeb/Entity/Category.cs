using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuraliWeb.Entity;

namespace TuraliWeb.Models
{
    public class Category:EntityBase
    {
        public int Id { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}