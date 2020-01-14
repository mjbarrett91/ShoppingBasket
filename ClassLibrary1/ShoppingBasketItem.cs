using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket
{
    public class ShoppingBasketItem : IShoppingBasketItem
    {
        public int Quantity { get => ItemQuantity; set => throw new NotImplementedException(); }

        public long Id => ItemId;

        public string Name => ItemName;

        public IEnumerable<ITaxRule> TaxRules => ItemTaxRules;

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        private string ItemName { get; set; }
        private long ItemId { get; set; }
        private int ItemQuantity { get; set; }
        private List<ITaxRule> ItemTaxRules { get; set; }

        public ShoppingBasketItem (IShoppingItem item)
        {
            ItemName = item.Name;
            ItemId = item.Id;
            //ItemTaxRules = item.TaxRules.ToList();
            ItemQuantity = 1;
        }
    }
}
