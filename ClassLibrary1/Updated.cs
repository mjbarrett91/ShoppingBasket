using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public class Updated : IUpdated
    {
        event EventHandler<ShoppingUpdatedEventArgs> IUpdated.Updated
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}
