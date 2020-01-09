using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public class ShoppingBasketItem : IShoppingBasketItem
    {
        public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IEnumerable<ITaxRule> TaxRules => throw new NotImplementedException();

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;
    }
}
