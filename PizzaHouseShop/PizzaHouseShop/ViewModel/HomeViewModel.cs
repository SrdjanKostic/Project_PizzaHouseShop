using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Models;

namespace PizzaHouseShop.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Pizza> PizzasOfTheWeek { get; set; }
    }
}
