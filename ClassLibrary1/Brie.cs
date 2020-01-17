using ShoppingBasket.Interfaces;
using System.Collections.Generic;
using tax = ShoppingBasket;

namespace ShoppingBasket
{
    public class Brie : IShoppingItem
    {
        public long Id => 3;
        public string Name => "Brie";
        public decimal UnitPrice => 10m;
        public IEnumerable<ITaxRule> TaxRules => taxRules;
        private readonly List<ITaxRule> taxRules = new List<ITaxRule>();

        public Brie()
        {
            taxRules.Add(tax.TaxRules.NoTax);
        }
    }
}