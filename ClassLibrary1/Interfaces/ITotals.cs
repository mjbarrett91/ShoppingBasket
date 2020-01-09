namespace ShoppingBasket.Interfaces
{
    public interface ITotals
    {
        decimal SubTotal { get; }
        decimal Tax { get; }
        decimal Total { get; }
    }
}
