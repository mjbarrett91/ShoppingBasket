using ShoppingBasket.Interfaces;
using System.Collections.Generic;
using tax = ShoppingBasket;

namespace ShoppingBasket
{
    public class Cheddar : IShoppingItem
    {
        public long Id => 1;
        public string Name => "Cheddar";
        public IEnumerable<ITaxRule> TaxRules
        {
            get
            {
                return tax.TaxRules.NoTax as List<ITaxRule>;
            }
        }
    }
}