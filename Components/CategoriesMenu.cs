using Microsoft.AspNetCore.Mvc;
using PieShop.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Components
{
    public class CategoriesMenu : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesMenu(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _unitOfWork.categoryRepository.AllCategories
                .OrderBy(c => c.CategoryName);

            return View(categories);
        }
    }
}
