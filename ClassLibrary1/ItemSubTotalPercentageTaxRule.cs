﻿using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ItemSubTotalPercentageTaxRule : ITaxRule
    {
        // TODO:Please provide the implementation of this type to calculate the tax as a percentage of the sub total for the item
        public decimal CalculateTax(IShoppingBasket basket, IShoppingBasketItem item)
        {
        }
    }
}
