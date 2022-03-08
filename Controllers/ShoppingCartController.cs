using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using PieShop.Models.Persistence.Repositories;
using PieShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           var items = _unitOfWork.CartRepository.GetShoppingCartItems();
            _unitOfWork.CartRepository.GetShoppingCart().ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _unitOfWork.CartRepository.GetShoppingCart(),
                ShoppingCartTotalPrice = _unitOfWork.CartRepository.GetCartTotalPrice()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddItem(int pieId)
        {
            var item = _unitOfWork.PieRepository
                .GetAllPies
                .FirstOrDefault(p => p.PieId == pieId);
            
            if(item != null)
            {
                _unitOfWork.CartRepository.AddItem(item, 1);
            }

           return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveItem(int pieId)
        {
            var item = _unitOfWork.PieRepository
                .GetAllPies
                .FirstOrDefault(p => p.PieId == pieId);

            if (item != null)
            {
                _unitOfWork.CartRepository.RemoveCartItem(item);
            }

            return RedirectToAction("Index");
        }
    }
}
