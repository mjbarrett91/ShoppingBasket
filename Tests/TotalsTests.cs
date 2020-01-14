using System;
using Xunit;

namespace Tests
{
    public class TotalsTests
    {
        //* After adding a single item to an empty basket, both the subtotal of the item and basket should equal the items unit price
        // * After adding a single item(with a NoTax rule) to an empty basket, both the tax of the item and the basket should equal 0 and both the subtotal of the item and basket should equal the items unit price
        //* After adding two items with different quantities(both with a NoTax rule) to an empty basket, both the tax of the item and the basket should equal 0, both the subtotal and the total of the item and basket should equal the items unit price
      
        [Fact]
        public void Test1()
        {

        }
    }
}
