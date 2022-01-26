using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuraliWeb.Entity
{
    public class EntityBase
    {
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Resim")]
        public string Image { get; set; }
    }
}