using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket
{
    public class ShoppingBasketItem : IShoppingBasketItem
    {
        public int Quantity { get; set; }

        public long Id { get; }

        public string Name { get; }

        public IEnumerable<ITaxRule> TaxRules { get; }

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public ShoppingBasketItem (IShoppingItem item)
        {
            Name = item.Name;
            Id = item.Id;
            //ItemTaxRules = item.TaxRules.ToList();
            Quantity = 1;
        }

        public ShoppingBasketItem(IShoppingItem item, int quantity)
        {
            Name = item.Name;
            Id = item.Id;
            //ItemTaxRules = item.TaxRules.ToList();
            Quantity = quantity;
        }
    }
}
