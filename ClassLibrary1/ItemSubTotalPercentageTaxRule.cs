using ShoppingBasket.Interfaces;
using System.Linq;

namespace ShoppingBasket
{
    public class ItemSubTotalPercentageTaxRule : ITaxRule
    {
        private readonly decimal Percentage;
        public ItemSubTotalPercentageTaxRule(decimal percentage)
        {
            Percentage = percentage/100;
        }

        //Please provide the implementation of this type to calculate the tax as a percentage of the sub total for the item
        public decimal CalculateTax(IShoppingBasket basket, IShoppingBasketItem item)
        {
            if (basket != null)
            {
                var itemToCalculate = basket.Items.FirstOrDefault(x => x.Id == item.Id);
                var tax = itemToCalculate.SubTotal * Percentage;
                return tax;
            }
            else
            {
                var tax = item.SubTotal * Percentage;
                return tax;
            }
        }
    }
}
