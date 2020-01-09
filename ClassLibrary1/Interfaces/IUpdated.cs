using System;

namespace ShoppingBasket.Interfaces
{
    public interface IUpdated
    {
        event EventHandler<ShoppingUpdatedEventArgs> Updated;
    }
}
