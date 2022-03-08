using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using PieShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            HomePieListViewModel piesOfWeek = new HomePieListViewModel
                { PiesOfTheWeek = _unitOfWork.PieRepository.PiesOfTheWeek };

            return View(piesOfWeek);
        }
    }
}
