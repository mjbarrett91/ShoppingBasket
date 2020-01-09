using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public IEnumerable<IShoppingBasketItem> Items => throw new NotImplementedException();

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public IShoppingBasketItem AddItem(IShoppingItem item)
        {
            throw new NotImplementedException();
        }

        public IShoppingBasketItem AddItem(IShoppingItem item, int quantity)
        {
            throw new NotImplementedException();
        }

        public IShoppingBasketItem RemoveItem(IShoppingBasketItem item)
        {
            throw new NotImplementedException();
        }
    }
}
