using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Interfaces;
using PizzaHouseShop.Models;

namespace PizzaHouseShop.Repositories
{
    public class MockPizzaRepository : IPizzaRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Pizza> Pizzas
        {
            get
            {
                return new List<Pizza>
                {
                    new Pizza { PizzaId = 1, Name = "Fresh Basil pizza", ShortDescription = "Grilled Tomato-Peach Pizza", LongDescription = "Regardess what else comes atop your pizza, a few fresh basil leaves will taste amazing with it. This simple sumertime pizza would make a delicious cookout appetizer or light dinner paired with a salad.",AllergyInformation = "No allergens", Price=15.95M, ImageUrl="/Images/Menu/Fresh_Brasil_pizza.png", ImageThumbnailUrl = "/Images/Menu/Fresh_Brasil_pizza.png", IsPizzaOfTheWeek = false, InStock = true, CategoryId=1, Category = _categoryRepository.Categorues.ToList()[0]},
                    new Pizza { PizzaId = 2, Name = "Extra Cheese pizza", ShortDescription = "Deep-Dish Skillet Pizza", LongDescription = "The Extra Cheese pizza is a deliciously rich option featuring a generous layer of melted mozzarella, creating a gooey, savory bite in every slice. Its cheesy goodness makes it a perfect comfort food for cheese lovers.", AllergyInformation = "Gluten", Price = 16.95M, ImageUrl = "/Images/Menu/Extra_Cheese_pizza.png", ImageThumbnailUrl = "/Images/Menu/Extra_Cheese_pizza.png", IsPizzaOfTheWeek = true, InStock = true, CategoryId = 3, Category = _categoryRepository.Categorues.ToList()[1] },
                    new Pizza { PizzaId = 3, Name = "Ham pizza", ShortDescription = "Fig, Ham, and Ricotta Pizza", LongDescription = "The Ham pizza offers a savory combination of tender, smoky ham slices atop a crispy crust, layered with tangy tomato sauce and melted cheese. This classic pizza brings a satisfying balance of flavors.", AllergyInformation = "No allergens", Price = 17.95M, ImageUrl = "/Images/Menu/Ham_pizza.png", ImageThumbnailUrl = "/Images/Menu/Ham_pizza.png", IsPizzaOfTheWeek = false, InStock = false, CategoryId = 2, Category = _categoryRepository.Categorues.ToList()[2] },
                    new Pizza { PizzaId = 4, Name = "Sausage pizza", ShortDescription = "Sausage and Kale Pesto Pizza", LongDescription = "The Sausage pizza features flavorful, seasoned sausage crumbles scattered over a bed of melted cheese and tangy tomato sauce. Its robust, savory taste makes it a hearty option.", AllergyInformation = "Gluten", Price = 14.95M, ImageUrl = "/Images/Menu/Sausage_pizza.png", ImageThumbnailUrl = "/Images/Menu/Sausage_pizza.png", IsPizzaOfTheWeek = false, InStock = true, CategoryId = 2, Category = _categoryRepository.Categorues.ToList()[3] },
                };
            }
        }

        public IEnumerable<Pizza> PizzasOfTheWeek => throw new NotImplementedException();

        public Pizza GetPizzaById(int pizzaId)
        {
            throw new NotImplementedException();
        }
    }
}
