using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public class Totals : ITotals
    {
        public decimal SubTotal => GetSubTotal();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        internal decimal GetSubTotal()
        {
            
        }
    }
}
