using PieShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModel
{
    public class HomePieListViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
