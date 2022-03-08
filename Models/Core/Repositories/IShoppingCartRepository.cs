using PieShop.Models.Core.Domain;
using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Core.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCart();
        void AddItem(Pie pie, int amount);
        int RemoveCartItem(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearShoppingCart();
        decimal GetCartTotalPrice();
    }
}
