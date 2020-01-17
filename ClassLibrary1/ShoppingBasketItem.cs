using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasketItem : IShoppingBasketItem
    {
        public int Quantity { get; set; }
        public long Id { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }
        public IEnumerable<ITaxRule> TaxRules { get => taxRules; }
        private readonly IEnumerable<ITaxRule> taxRules;

        public decimal SubTotal => GetItemSubTotal();
        public decimal Tax => GetItemTax();
        public decimal Total => GetItemTotal();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public ShoppingBasketItem(IShoppingItem item)
        {
            Name = item.Name;
            Id = item.Id;
            Quantity = 1;
            UnitPrice = item.UnitPrice;
            taxRules = item.TaxRules;
        }

        public ShoppingBasketItem(IShoppingItem item, int quantity)
        {
            Name = item.Name;
            Id = item.Id;
            Quantity = quantity;
            UnitPrice = item.UnitPrice;
            taxRules = item.TaxRules;
        }

        private decimal GetItemSubTotal()
        {
            return Quantity * UnitPrice;
        }

        private decimal GetItemTax()
        {
            //var basket = new ShoppingBasket();
            var itemTax = new decimal();
            foreach (var taxRule in TaxRules)
            {
                itemTax += taxRule.CalculateTax(null, this);
            }
            return itemTax;
        }

        private decimal GetItemTotal()
        {
            return GetItemSubTotal() + GetItemTax();
        }
    }
}
