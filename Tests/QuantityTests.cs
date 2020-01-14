using FluentAssertions;
using ShoppingBasket;
using ShoppingBasket.Interfaces;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Tests
{
    public class QuantityTests : TestSetup
    {
        //* Adding an item without an explicit quantity results in a quantity of 1 for the item
        //* After adding a single item to an empty basket, both the basket and item quantity are 1
        //* After adding two items with different quantities to an empty basket, both the basket and item quantities are correct
        //* After updating the quantity on an item already in a basket, both the basket and item quantities are correct
        //* Adding an item with, or updating an item to a quantity of 0 or less will result in an ArgumentOutOfRangeException being thrown
        //* After adding a single item to the basket, adding the same item again will update the quantity of the previously added item

        [Fact]
        public void AddItemWithoutQuantity()
        {
            BeforeTest();
            var item = new Cheese();
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.Should().HaveCount(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(1);
            AfterTest();
        }

        [Fact]
        public void ItemQuantityChange()
        {
            BeforeTest();
            var basket = new ShoppingBasket.ShoppingBasket();
            basket.AddItem(new Cheese(), 1);
            Console.WriteLine(basket.SubTotal);
            basket.Items.First().Quantity = 100;
            Console.WriteLine(basket.SubTotal);
            AfterTest();
        }
    }
}
