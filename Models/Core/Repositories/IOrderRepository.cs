using PieShop.Models.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Core.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
