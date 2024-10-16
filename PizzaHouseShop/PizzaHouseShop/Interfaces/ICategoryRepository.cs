using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHouseShop.Models;
namespace PizzaHouseShop.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categorues { get; }
    }
}
