using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int PieId);
        IEnumerable<Pie> GetPiesByCategory(string category);

    }
}
