using ShoppingBasket.Interfaces;

namespace ShoppingBasket
{
    public static class TaxRules
    {
        public static ITaxRule NoTax = new ItemSubTotalPercentageTaxRule(0m);

        public static ITaxRule TenPercentTax = new ItemSubTotalPercentageTaxRule(10m);
    }
}
