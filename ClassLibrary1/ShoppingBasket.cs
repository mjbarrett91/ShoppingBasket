using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public IEnumerable<IShoppingBasketItem> Items => Basket;
        private List<IShoppingBasketItem> Basket { get; set; }

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public IShoppingBasketItem AddItem(IShoppingItem item)
        {
            Basket = new List<IShoppingBasketItem>();
            var newShoppingBasketItem = new ShoppingBasketItem(item) as IShoppingBasketItem;

            if (Items != null)
            {
                Basket = Items.ToList();
                var itemExists = Basket.Find(x => x.Id == item.Id);
                if (itemExists != null)
                {
                    itemExists.Quantity++;
                    //Updated();
                    return itemExists;
                }
            }
            //var newItem = new ShoppingBasketItem { Name = null, Quantity = 1, TaxRules = null }() as IShoppingBasketItem;
            Basket.Add(newShoppingBasketItem);
            //Updated();
            //this.Items = itemList;
            return newShoppingBasketItem;

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
