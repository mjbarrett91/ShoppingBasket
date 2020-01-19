using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public class ShoppingBasketItem : IShoppingBasketItem
    {
        public int Quantity { get; set; }
        public long Id { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }
        public IEnumerable<ITaxRule> TaxRules { get; }

        public decimal SubTotal => GetItemSubTotal();
        public decimal Tax => GetItemTax();
        public decimal Total => GetItemTotal();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;
        public virtual void OnUpdate() => Updated?.Invoke(this, new ShoppingUpdatedEventArgs());

        public ShoppingBasketItem()
        {
        }

        public ShoppingBasketItem(IShoppingItem item)
        {
            Name = item.Name;
            Id = item.Id;
            Quantity = 1;
            UnitPrice = item.UnitPrice;
            TaxRules = item.TaxRules;
            OnUpdate();
        }

        public ShoppingBasketItem(IShoppingItem item, int quantity)
        {
            Name = item.Name;
            Id = item.Id;
            Quantity = quantity;
            UnitPrice = item.UnitPrice;
            TaxRules = item.TaxRules;
            OnUpdate();
        }

        private decimal GetItemSubTotal()
        {
            return Quantity * UnitPrice;
        }

        private decimal GetItemTax()
        {
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
