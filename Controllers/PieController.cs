using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using PieShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PieController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public ViewResult List(string category)
        {
            var listViewModel = new PiesListViewModel();

            if (string.IsNullOrEmpty(category))
            {
                listViewModel.Pies = _unitOfWork.PieRepository.GetAllPies;
                listViewModel.currentCategory = "All Pies";
            }
            else
            {
                listViewModel.Pies = _unitOfWork.PieRepository.GetPiesByCategory(category);
                listViewModel.currentCategory = category;
            }

            return View(listViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _unitOfWork.PieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
