using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHouseShop.Interfaces;
using PizzaHouseShop.Models;
using PizzaHouseShop.ViewModel;

namespace PizzaHouseShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PizzaController(IPizzaRepository pizzaRepository, ICategoryRepository categoryRepository)
        {
            _pizzaRepository = pizzaRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pizza> pizzas;
            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category))
            {
                pizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId);
                currentCategory = "All pizzas";
            }
            else
            {
                pizzas = _pizzaRepository.Pizzas.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PizzaId);
                currentCategory = _categoryRepository.Categorues.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }
            return View(new PizzaListViewModel
            {
                Pizzas = pizzas,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pizza = _pizzaRepository.GetPizzaById(id);
            if(pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
