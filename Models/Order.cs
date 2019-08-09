using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WlBhcApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customer customer { get; set; } 
        [Required]
        public int ProductID { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderedDate { get; set; }
    }
}