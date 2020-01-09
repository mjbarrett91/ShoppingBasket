﻿using System.Collections.Generic;

namespace ShoppingBasket.Interfaces
{
    public interface IShoppingBasket : ITotals, IUpdated
    {
        IShoppingBasketItem AddItem(IShoppingItem item);
        IShoppingBasketItem AddItem(IShoppingItem item, int quantity);
        IShoppingBasketItem RemoveItem(IShoppingBasketItem item);

        IEnumerable<IShoppingBasketItem> Items { get; }
    }
}
