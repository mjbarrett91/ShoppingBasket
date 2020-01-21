using ShoppingBasket.Interfaces;

namespace ShoppingBasket
{
    public static class TaxRules
    {
        //Made Readonly as Rules should not be changed
        public readonly static ITaxRule NoTax = new ItemSubTotalPercentageTaxRule(0m);
        public readonly static ITaxRule TenPercentTax = new ItemSubTotalPercentageTaxRule(10m);
    }
}
