namespace ShoppingBasket.Interfaces
{
    public interface IShoppingBasketItem : IShoppingItem, ITotals, IUpdated
    {
        int Quantity { get; set; }
    }
}
