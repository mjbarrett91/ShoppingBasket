using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ItemSubTotalPercentageTaxRule : ITaxRule
    {
        private readonly decimal Percentage;
        public ItemSubTotalPercentageTaxRule(decimal percentage)
        {
            Percentage = percentage;
        }

        // TODO:Please provide the implementation of this type to calculate the tax as a percentage of the sub total for the item
        public decimal CalculateTax(IShoppingBasket basket, IShoppingBasketItem item)
        {
            var itemToCalculate = basket.Items.FirstOrDefault(x => x.Id == item.Id);
            var tax = itemToCalculate.SubTotal * Percentage; //basketItems.Price????? // No Price exists anywhere?
            return tax;
        }
    }
}
