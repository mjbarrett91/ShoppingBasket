﻿using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        public IEnumerable<IShoppingBasketItem> Items => Basket;
        private List<IShoppingBasketItem> Basket;

        public decimal SubTotal => GetBasketSubTotal();
        public decimal Tax => GetBasketTax();
        public decimal Total => GetBasketTotal();

        public event EventHandler<ShoppingUpdatedEventArgs> Updated;
        public virtual void OnBasketUpdate() => Updated?.Invoke(this, new ShoppingUpdatedEventArgs());
        private readonly IShoppingBasketItem shoppingBasketItem;

        public ShoppingBasket()
        {
            Basket = new List<IShoppingBasketItem>();
            shoppingBasketItem = new ShoppingBasketItem() as IShoppingBasketItem;
            shoppingBasketItem.Updated += (sender, args) => CalculateTotalsOnUpdate(sender, args);
        }

        private void CalculateTotalsOnUpdate(object sender, ShoppingUpdatedEventArgs args)
        {
            GetBasketSubTotal();
            GetBasketTax();
            GetBasketTotal();
        }

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
                return itemExists;
            }
            Basket.Add(itemToAdd);
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
                itemExists.Quantity += quantity;
                if (itemExists.Quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException($"The item {itemExists.Name} had a quantity of {itemExists.Quantity}, this cannot be less than or equal to 0");
                }
                Basket.Add(itemExists);
                return itemExists;
            }
            Basket.Add(itemToAdd);
            return itemToAdd;
        }

        public IShoppingBasketItem RemoveItem(IShoppingBasketItem item)
        {
            Basket = Items?.ToList() ?? new List<IShoppingBasketItem>();
            var itemExists = Basket.Find(x => x.Id == item.Id);
            if (itemExists != null)
            {
                Basket.Remove(itemExists);
                return itemExists;
            }

            Basket.Add(item);
            return item;
        }
        private decimal GetBasketSubTotal()
        {
            var subTotal = new decimal(0);
            foreach (var basketItems in Items)
            {
                subTotal += basketItems.SubTotal; 
            }
            return subTotal;
        }

        private decimal GetBasketTotal()
        {
            var subTotal = GetBasketSubTotal();
            var tax = GetBasketTax();
            var total = subTotal + tax;

            return total;
        }

        private decimal GetBasketTax()
        {
            var tax = new decimal(0);
            foreach (var basketItem in Items)
            {
                foreach (var taxRule in basketItem.TaxRules)
                {
                    tax += taxRule.CalculateTax(this as IShoppingBasket, basketItem);
                }
            }
            return tax;
        }
    }
}
