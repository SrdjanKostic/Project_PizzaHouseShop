using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Interfaces;
using PizzaHouseShop.Models;

namespace PizzaHouseShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
        }
    }
}
