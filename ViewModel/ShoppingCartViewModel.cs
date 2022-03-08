using PieShop.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart{ get; set; }
        public decimal ShoppingCartTotalPrice { get; set; }
    }
}
