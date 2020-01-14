using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public class Totals : ITotals
    {
        public decimal SubTotal => GetSubTotal();

        public decimal Tax => GetTax();

        public decimal Total => GetTotal();

        private readonly IShoppingBasket _shoppingBasket;

        public Totals(IShoppingBasket shoppingBasket)
        {
            _shoppingBasket = shoppingBasket ?? throw new ArgumentNullException(nameof(shoppingBasket));
        }

        internal decimal GetSubTotal()
        {
            var total = new decimal(0);
            foreach (var basketItems in _shoppingBasket.Items)
            {
                total = basketItems.Quantity * 1; //basketItems.Price????? // No Price exists anywhere?
            }
                               
            return total;
        }

        internal decimal GetTotal()
        {
            return new decimal(0);
                }

        internal decimal GetTax()
        {
            return new decimal(0);
        }
    }
}
