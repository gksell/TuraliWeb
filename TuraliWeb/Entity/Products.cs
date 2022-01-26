using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TuraliWeb.Entity;

namespace TuraliWeb.Models
{
    public class Products:EntityBase
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Pdf Formatı")]
        public string PDF { get; set; }
        [DisplayName("Yüklenme Tarihi")]

        public DateTime? UploadTime { get; set; }
        [Required]
        [DisplayName("Ürün Fiyatı")]
        public int Price { get; set; }
        [DisplayName("OnayDurumu")]
        public bool IsApproved { get; set; }


        public int SubSubCategoryId { get; set; }

        public virtual SubSubCategory SubSubCategory { get; set; }
    }
}