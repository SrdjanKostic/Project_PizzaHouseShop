using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Interfaces;
using PizzaHouseShop.Models;
namespace PizzaHouseShop.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category>Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryId = 1, CategoryName = "Vegan pizza", Description = "Short description"},
                    new Category { CategoryId = 2, CategoryName = "Ham pizza", Description = "Short description"},
                    new Category { CategoryId = 3, CategoryName = "Chesse pizza", Description = "Short description"},
                };
            }
        }

        public IEnumerable<Category> Categorues => throw new NotImplementedException();
    }
}
