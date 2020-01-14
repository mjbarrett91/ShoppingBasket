using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public IEnumerable<IShoppingBasketItem> Items => Basket;
        private List<IShoppingBasketItem> Basket;

        public decimal SubTotal => throw new NotImplementedException();

        public decimal Tax => throw new NotImplementedException();

        public decimal Total => throw new NotImplementedException();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;

        public IShoppingBasketItem AddItem(IShoppingItem item)
        {
            Basket = Items?.ToList() ?? new List<IShoppingBasketItem>();
            var itemToAdd = new ShoppingBasketItem(item) as IShoppingBasketItem;
            var itemExists = Basket.Find(x => x.Id == itemToAdd.Id);
            if (itemExists != null)
            {
                Basket.Remove(itemExists);
                itemExists.Quantity++;
                Basket.Add(itemExists);
                //Updated();
                return itemExists;
            }

            Basket.Add(itemToAdd);
            //Updated();
            return itemToAdd;
        }


        public IShoppingBasketItem AddItem(IShoppingItem item, int quantity)
        {
            Basket = Items?.ToList() ?? new List<IShoppingBasketItem>();
            var itemToAdd = new ShoppingBasketItem(item, quantity) as IShoppingBasketItem;
            var itemExists = Basket.Find(x => x.Id == itemToAdd.Id);
            if (itemExists != null)
            {
                Basket.Remove(itemExists);
                itemExists.Quantity = itemExists.Quantity + quantity;
                if (itemExists.Quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException($"The item {itemExists.Name} had a quantity of {itemExists.Quantity}, this cannot be less than or equal to 0");
                }
                Basket.Add(itemExists);
                //Updated();
                return itemExists;
            }


            Basket.Add(itemToAdd);
            //Updated();
            return itemToAdd;
        }

        public IShoppingBasketItem RemoveItem(IShoppingBasketItem item)
        {
            Basket = Items?.ToList() ?? new List<IShoppingBasketItem>();
            var itemToRemove = new ShoppingBasketItem(item) as IShoppingBasketItem;
            var itemExists = Basket.Find(x => x.Id == itemToRemove.Id);
            if (itemExists != null)
            {
                Basket.Remove(itemExists);
                //Updated();
                return itemExists;
            }

            Basket.Add(itemToRemove);
            //Updated();
            return itemToRemove;
        }

    }
}
