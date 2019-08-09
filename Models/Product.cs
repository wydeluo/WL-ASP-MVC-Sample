using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WlBhcApp.Models
{
    public class Product
    {
        [Required]
        public int ID { get; set; }
        [DisplayName("Product Name")]
        [MaxLength(50)]
        [Required]
        public string ProdName { get; set; }
        [DisplayName("Product Details")]
        [MaxLength(255)]
        public string  ProdDescription { get; set; }
        [Required]
        public double Price { get; set; }
        [DisplayName("Product Attributes")]
        [MaxLength(255)]
        public string ProdAttributes { get; set; }

    }
}