using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDataContext _dataContext;

        public CategoryRepository(AppDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        IEnumerable<Category> ICategoryRepository.AllCategories => _dataContext.Categories;
    }
}
