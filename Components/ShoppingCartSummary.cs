using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IUnitOfWork _unintOfWork;

        public ShoppingCartSummary(IUnitOfWork unintOfWork)
        {
            _unintOfWork = unintOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var items = _unintOfWork.CartRepository.GetShoppingCartItems();
            return View(items.Count);
        }

    }
}
