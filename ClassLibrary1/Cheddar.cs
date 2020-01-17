using ShoppingBasket.Interfaces;
using System.Collections.Generic;
using tax = ShoppingBasket;

namespace ShoppingBasket
{
    public class Cheddar : IShoppingItem
    {
        public long Id => 1;
        public string Name => "Cheddar";
        public decimal UnitPrice => 10m;
        public IEnumerable<ITaxRule> TaxRules => taxRules;
        private readonly List<ITaxRule> taxRules = new List<ITaxRule>();

        public Cheddar()
        {
            taxRules.Add(tax.TaxRules.NoTax);
        }
    }
}