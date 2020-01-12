using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public IEnumerable<IShoppingBasketItem> Items => new List<IShoppingBasketItem>(); //Just to start

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public IShoppingBasketItem AddItem(IShoppingItem item)
        {
            var itemList = Items.ToList();
            var itemExists = false;

            foreach (var x in itemList)
            {
                if (x.Id == item.Id)
                {
                    x.Quantity = 1;
                    itemExists = true;
                }
            }

            //Convert Item to IShoppingBasketItem
            var newItem = new ShoppingBasketItem() as IShoppingBasketItem;
            
            //newItem.Id = item.Id; // Readonly can't set

            if (!itemExists)
            {
                itemList.Add(item);
            }

            return newBasketItem;
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
