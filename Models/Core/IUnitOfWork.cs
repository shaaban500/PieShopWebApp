using PieShop.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Core
{
    public interface IUnitOfWork
    {
        IPieRepository PieRepository { get; set; }
        IShoppingCartRepository CartRepository { get; set; }
        ICategoryRepository categoryRepository { get; set; }
        IOrderRepository orderRepository { get; set; }
    }
}
