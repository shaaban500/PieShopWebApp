using Microsoft.EntityFrameworkCore;
using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Persistence
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDataContext _dataContext;
        private readonly ICategoryRepository _categoryRepository;
        public PieRepository(AppDataContext dataContext)
        {
            this._dataContext = dataContext;
            _categoryRepository = new CategoryRepository(dataContext);
        }
        public IEnumerable<Pie> GetAllPies => _dataContext.Pies.Include(c => c.Category);

        public Pie GetPieById(int PieId)
        {
            return _dataContext.Pies.FirstOrDefault(p => p.PieId == PieId);
        }

        public IEnumerable<Pie> PiesOfTheWeek => _dataContext.Pies.Where(p => p.IsPieOfTheWeek);

        public IEnumerable<Pie> GetPiesByCategory(string category)
        {
            return _dataContext.Pies.Where(p => p.Category.CategoryName == category);
        }
    }
}
