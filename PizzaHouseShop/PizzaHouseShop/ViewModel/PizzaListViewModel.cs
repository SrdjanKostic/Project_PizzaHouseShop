using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Models;
namespace PizzaHouseShop.ViewModel
{
    public class PizzaListViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; }
        public string CurrentCategory { get; set; }
    }
}
