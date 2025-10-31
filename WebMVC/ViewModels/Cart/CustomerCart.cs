using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Web.ViewModels.Cart
{
    public class CustomerCart
    {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}