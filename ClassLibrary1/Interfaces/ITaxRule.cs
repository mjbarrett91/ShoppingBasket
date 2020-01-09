namespace ShoppingBasket.Interfaces
{
    public interface ITaxRule
    {
        decimal CalculateTax(IShoppingBasket basket, IShoppingBasketItem item);
    }
}
