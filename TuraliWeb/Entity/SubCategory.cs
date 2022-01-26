using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TuraliWeb.Entity;

namespace TuraliWeb.Models
{
    public class SubCategory:EntityBase
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public virtual List<SubSubCategory> SubSubCategories { get; set; }
        public virtual Category Category { get; set; }
    }
}