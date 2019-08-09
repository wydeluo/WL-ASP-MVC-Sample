using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WlBhcApp.Models
{
    public class Customer
    {
        [Required]
        public int ID { get; set; }
        [DisplayName("First Name")]
        [MaxLength(50)]
        [Required]
        public string Firstname { get; set; }
        [DisplayName("Middle Name")]
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        [MaxLength(50)]
        [Required]
        public string Lastname { get; set; }
        [DisplayName("Email")]
        [MaxLength(50)]
        [Required]
        public string  EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        [MaxLength(50)]
        [Required]
        public string Phone { get; set; }
        [DisplayName("Address 1")]
        [MaxLength(100)]
        [Required]
        public string Address1  { get; set; }
        [DisplayName("Address 2")]
        [MaxLength(50)]
        public string  Address2 { get; set; }
        [DisplayName("City")]
        [MaxLength(50)]
        [Required]
        public string  City { get; set; }
        [DisplayName("State")]
        [MaxLength(50)]
        [Required]
        public string State { get; set; }
        [DisplayName("Zip")]
        [MaxLength(20)]
        public string ZipCode { get; set; }
    }
}