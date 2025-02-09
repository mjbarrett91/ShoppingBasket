﻿using ShoppingBasket.Interfaces;
using System.Collections.Generic;
using tax = ShoppingBasket;

namespace ShoppingBasket
{
    public class Camembert : IShoppingItem
    {
        public long Id => 2;
        public string Name => "Camembert";
        public decimal UnitPrice => 20m;
        public IEnumerable<ITaxRule> TaxRules => taxRules;
        private readonly List<ITaxRule> taxRules = new List<ITaxRule>();

        public Camembert()
        {
            taxRules.Add(tax.TaxRules.TenPercentTax);
        }
    }
}