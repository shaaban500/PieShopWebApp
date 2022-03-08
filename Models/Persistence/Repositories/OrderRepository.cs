using PieShop.Models.Core.Domain;
using PieShop.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _dataContext;
        private ShoppingCart _ShoppingCart { get; set; }


        public OrderRepository(AppDataContext dataContext, ShoppingCart shoppingCart)
        {
            this._dataContext = dataContext;
            _ShoppingCart = shoppingCart;

        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            
            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in _ShoppingCart.ShoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();
        }
    }
}
