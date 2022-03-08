using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using PieShop.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _unitOfWork.CartRepository.GetShoppingCartItems();
            _unitOfWork.CartRepository.GetShoppingCart().ShoppingCartItems = items;

            if (items.Count == 0)
            {
                ModelState.AddModelError("", "You can't checkout with the cart is empty");
            }
            
            if(ModelState.IsValid)
            {
                _unitOfWork.orderRepository.CreateOrder(order);
                _unitOfWork.CartRepository.ClearShoppingCart();
                return RedirectToAction("CheckoutCompleted");
            }

            return View();
        }

        public IActionResult CheckoutCompleted()
        {
            ViewBag.Message = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
