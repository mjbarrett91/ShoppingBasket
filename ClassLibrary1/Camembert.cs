using ShoppingBasket.Interfaces;
using System.Collections.Generic;
using tax = ShoppingBasket;

namespace ShoppingBasket
{
    public class Camembert : IShoppingItem
    {
        public long Id => 2;
        public string Name => "Camembert";
        public IEnumerable<ITaxRule> TaxRules => tax.TaxRules.TenPercentTax as List<ITaxRule>;
        public decimal UnitPrice => 25m;
    }
}