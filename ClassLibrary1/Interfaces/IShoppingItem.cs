using System.Collections.Generic;

namespace ShoppingBasket.Interfaces
{
    public interface IShoppingItem
    {
        long Id { get; }
        string Name { get; }
        IEnumerable<ITaxRule> TaxRules { get; }
    }
}
