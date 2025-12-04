using System.Globalization;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a pre-configured template for a pizza a user can order
    /// </summary>
    public class PizzaSpecial
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BasePrice { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        // Format price as Philippine Peso (₱)
        public string GetFormattedBasePrice()
            => BasePrice.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
    }
}
