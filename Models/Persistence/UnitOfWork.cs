using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models.Core;
using PieShop.Models.Core.Domain;
using PieShop.Models.Core.Repositories;
using PieShop.Models.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext dataContext;
        public IPieRepository PieRepository { get; set; }
        public IShoppingCartRepository CartRepository { get; set; }
        public ICategoryRepository categoryRepository { get; set; }
        public IOrderRepository orderRepository { get; set; }

        public UnitOfWork(AppDataContext dataContext, ShoppingCart shoppingCart)
        {
            PieRepository = new PieRepository(dataContext);
            CartRepository = new ShoppingCartRepository(dataContext, shoppingCart);
            categoryRepository = new CategoryRepository(dataContext);
            orderRepository = new OrderRepository(dataContext, shoppingCart);
            this.dataContext = dataContext;
        }

       
    }
}
