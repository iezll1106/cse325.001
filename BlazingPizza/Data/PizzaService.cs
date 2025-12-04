using System.Threading.Tasks;
using BlazingPizza.Data; // <-- REQUIRED

namespace BlazingPizza.Data
{
    public class PizzaService
    {
        public Task<Pizza[]> GetPizzasAsync()
        {
            // Example data. Replace with database call later.
            return Task.FromResult(new[]
            {
                new Pizza
                {
                    PizzaId = 1,
                    Name = "Pepperoni Pizza",
                    Description = "A classic pepperoni pizza.",
                    Price = 9.99m,
                    Vegetarian = false,
                    Vegan = false,
                    ImageUrl = "img/pizzas/pepperoni.jpg"
                },
                new Pizza
                {
                    PizzaId = 2,
                    Name = "Veggie Pizza",
                    Description = "Loaded with vegetables.",
                    Price = 8.99m,
                    Vegetarian = true,
                    Vegan = false,
                    ImageUrl = "img/pizzas/veggie.jpg"
                }
            });
        }
    }
}