using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaHouseShop.Interfaces;
using PizzaHouseShop.Models;
namespace PizzaHouseShop.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _appDbContext;

        public PizzaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pizza> Pizzas
        {
            get
            {
                return _appDbContext.Pizza.Include(c => c.Category);
            }
        }

        public IEnumerable<Pizza> PizzasOfTheWeek
        {
            get
            {
                return _appDbContext.Pizza.Include(c => c.Category).Where(p => p.IsPizzaOfTheWeek);
            }
        }

        public Pizza GetPizzaById(int pizzaId)
        {
            return _appDbContext.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
        }
    }
}
