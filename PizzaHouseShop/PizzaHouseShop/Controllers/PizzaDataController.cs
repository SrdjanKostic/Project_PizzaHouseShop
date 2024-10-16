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
    [Route("api/[controller]")]
    public class PizzaDataController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaDataController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public IEnumerable<PizzaViewModel> LoadMorePizzas()
        {
            IEnumerable<Pizza> dbPizzas = null;
            dbPizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId).Take(10);
            List<PizzaViewModel> pizzas = new List<PizzaViewModel>();

            foreach(var dbPizza in dbPizzas)
            {
                pizzas.Add(MapDbPieToPieViewModel(dbPizza));
            }
            return pizzas;
        }

        private PizzaViewModel MapDbPieToPieViewModel(Pizza dbPizza)
        {
            return new PizzaViewModel()
            {
                PizzaId = dbPizza.PizzaId,
                Name = dbPizza.Name,
                Price = dbPizza.Price,
                ShortDescription = dbPizza.ShortDescription,
                ImageThumbnailUrl = dbPizza.ImageThumbnailUrl

            };
        }
    }
}
