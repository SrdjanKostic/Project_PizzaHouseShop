using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PizzaHouseShop.Models
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set;}
        public DbSet<Order> Order { get; set;}
        public DbSet<OrderDetail> OrderDetail { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Vegan pizza", Description = "Short description" },
                new Category { CategoryId = 2, CategoryName = "Ham pizza", Description = "Short description" },
                new Category { CategoryId = 3, CategoryName = "Chesse pizza", Description = "Short description" }
                );


            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { PizzaId = 1, Name = "Fresh Basil pizza", ShortDescription = "Grilled Tomato-Peach Pizza", LongDescription = "Regardess what else comes atop your pizza, a few fresh basil leaves will taste amazing with it. This simple sumertime pizza would make a delicious cookout appetizer or light dinner paired with a salad.", AllergyInformation = "No allergens", Price = 15.95M, ImageUrl = "", ImageThumbnailUrl = "", IsPizzaOfTheWeek = false, InStock = true, CategoryId = 1, },
                new Pizza { PizzaId = 2, Name = "Extra Cheese pizza", ShortDescription = "Deep-Dish Skillet Pizza", LongDescription = "The Extra Cheese pizza is a deliciously rich option featuring a generous layer of melted mozzarella, creating a gooey, savory bite in every slice. Its cheesy goodness makes it a perfect comfort food for cheese lovers.", AllergyInformation = "Gluten", Price = 16.95M, ImageUrl = "", ImageThumbnailUrl = "", IsPizzaOfTheWeek = true, InStock = true, CategoryId = 3 },
                new Pizza { PizzaId = 3, Name = "Ham pizza", ShortDescription = "Fig, Ham, and Ricotta Pizza", LongDescription = "The Ham pizza offers a savory combination of tender, smoky ham slices atop a crispy crust, layered with tangy tomato sauce and melted cheese. This classic pizza brings a satisfying balance of flavors.", AllergyInformation = "No allergens", Price = 17.95M, ImageUrl = "", ImageThumbnailUrl = "", IsPizzaOfTheWeek = false, InStock = false, CategoryId = 2 },
                new Pizza { PizzaId = 4, Name = "Sausage pizza", ShortDescription = "Sausage and Kale Pesto Pizza", LongDescription = "The Sausage pizza features flavorful, seasoned sausage crumbles scattered over a bed of melted cheese and tangy tomato sauce. Its robust, savory taste makes it a hearty option.", AllergyInformation = "Gluten", Price = 14.95M, ImageUrl = "", ImageThumbnailUrl = "", IsPizzaOfTheWeek = false, InStock = true, CategoryId = 2 }
                );
        }
    }
}
