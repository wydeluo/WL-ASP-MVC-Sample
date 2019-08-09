using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WlBhcApp.Models;

namespace WlBhcApp.ViewModels
{
    public class NewOrder
    {
        public Order order { get; set; }
        public Customer customer { get; set; }

    }
}