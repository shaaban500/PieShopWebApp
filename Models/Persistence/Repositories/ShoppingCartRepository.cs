using Microsoft.EntityFrameworkCore;
using PieShop.Models.Core.Domain;
using PieShop.Models.Core.Repositories;
using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Persistence.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDataContext _dataContext;
        private ShoppingCart _ShoppingCart { get; set; }

        public ShoppingCartRepository(AppDataContext dataContext, ShoppingCart shoppingCart)
        {
            this._dataContext = dataContext;
            _ShoppingCart = shoppingCart;
        }

        public ShoppingCart GetShoppingCart()
        {
            return _ShoppingCart;
        }
        public void AddItem(Pie pie, int amount)
        {
            var pieItem = _dataContext.ShppingCartItems
                            .SingleOrDefault(i => i.ShoppingCartId == _ShoppingCart.ShoppingCartId && i.Pie.PieId == pie.PieId);

            if (pieItem == null)
            {
                var ShoppingCartitem = new ShoppingCartItem
                {
                    Pie = pie,
                    Amount = 1,
                    ShoppingCartId = _ShoppingCart.ShoppingCartId,
                };

                _dataContext.ShppingCartItems.Add(ShoppingCartitem);
            }
            else
            {
                pieItem.Amount++;

            }

            _dataContext.SaveChanges();
        }

        public void ClearShoppingCart()
        {
            var ShoppingCartItems = _dataContext.ShppingCartItems
                .Where(s => s.ShoppingCartId == _ShoppingCart.ShoppingCartId);

            if (ShoppingCartItems != null)
            {
                _dataContext.ShppingCartItems.RemoveRange(ShoppingCartItems);
                _dataContext.SaveChanges();
            }
        }

        public decimal GetCartTotalPrice()
        {
            return _dataContext.ShppingCartItems
                .Where(s => s.ShoppingCartId == _ShoppingCart.ShoppingCartId)
                .Select(s => s.Pie.Price * s.Amount)
                .Sum();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _ShoppingCart.ShoppingCartItems ?? (_dataContext.ShppingCartItems
               .Include(s => s.Pie)
               .Where(s => s.ShoppingCartId == _ShoppingCart.ShoppingCartId).ToList());
        }

        public int RemoveCartItem(Pie pie)
        {
            var pieItem = _dataContext.ShppingCartItems
                           .SingleOrDefault(i => i.ShoppingCartId == _ShoppingCart.ShoppingCartId && i.Pie.PieId == pie.PieId);

            var localAmount = 0;

            if (pieItem != null)
            {
                if (pieItem.Amount > 1)
                {
                    pieItem.Amount--;
                    localAmount = pieItem.Amount;
                }
                else
                {
                    _dataContext.ShppingCartItems.Remove(pieItem);
                }

                _dataContext.SaveChanges();
            }

            return localAmount;
        }
    }
}
