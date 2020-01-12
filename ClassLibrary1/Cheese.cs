using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public class Cheese : IShoppingItem
    {
        public long Id => 1;
        public string Name => "Cheese";
        public IEnumerable<ITaxRule> TaxRules => throw new NotImplementedException();
    }
}