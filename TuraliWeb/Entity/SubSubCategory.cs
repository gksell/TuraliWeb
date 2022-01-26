using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TuraliWeb.Entity;

namespace TuraliWeb.Models
{
    public class SubSubCategory:EntityBase
    {
        public int Id { get; set; }   
        public int SubCategoryId { get; set; }

        public virtual List<Products> Products { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}