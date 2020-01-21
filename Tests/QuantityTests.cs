using FluentAssertions;
using ShoppingBasket;
using ShoppingBasket.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class QuantityTests : TestSetup
    {
        //* Adding an item without an explicit quantity results in a quantity of 1 for the item
        [Fact]
        public void AddItemWithoutQuantity()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(1);
            AfterTest();
        }

        //* After adding a single item to an empty basket, both the basket and item quantity are 1
        [Fact]
        public void AddBasketAndItemQuantitiesCorrect()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(1);
            AfterTest();
        }

        //* After adding two items with different quantities to an empty basket, both the basket and item quantities are correct
        [Fact]
        public void Add2ItemsWithDifferentQuantity()
        {
            BeforeTest();
            var item1 = new Cheddar() as IShoppingItem;
            var item2 = new Camembert() as IShoppingItem;
            shoppingBasket.AddItem(item1, 5);
            shoppingBasket.AddItem(item2, 10);
            shoppingBasket.Items.Count().Should().Be(2);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item1.Id).Quantity.Should().Be(5);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item2.Id).Quantity.Should().Be(10);
            AfterTest();
        }

        //* After updating the quantity on an item already in a basket, both the basket and item quantities are correct
        [Fact]
        public void ItemQuantityChange()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item, 2);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == 1).Quantity.Should().Be(2);
            shoppingBasket.Items.First().Quantity = 100;
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == 1).Quantity.Should().Be(100);
            AfterTest();
        }

        //* Adding an item with, or updating an item to a quantity of 0 or less will result in an ArgumentOutOfRangeException being thrown
        [Fact]
        public void AddItemsWith0QuantityGivesValidException()
        {
            BeforeTest();
            var item1 = new Cheddar() as IShoppingItem;
            try
            {
                shoppingBasket.AddItem(item1, 0);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType(typeof(ArgumentOutOfRangeException));
            }
            AfterTest();
        }

        //* After adding a single item to the basket, adding the same item again will update the quantity of the previously added item
        [Fact]
        public void AddExistingItemWithoutQuantity()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(1);
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(2);
            AfterTest();
        }

        //Test Removal of Item added previously
        [Fact]
        public void RemoveItemAdded()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item);
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == item.Id).Quantity.Should().Be(1);
            shoppingBasket.RemoveItem(shoppingBasket.Items.FirstOrDefault());
            shoppingBasket.Items.Count().Should().Be(0);
            AfterTest();
        }

        //Test Removal of Item added previously
        [Fact]
        public void RemoveOneItemAdded()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            var item2 = new Camembert() as IShoppingItem;
            shoppingBasket.AddItem(item);
            shoppingBasket.AddItem(item2);
            shoppingBasket.Items.Count().Should().Be(2);
            shoppingBasket.RemoveItem(shoppingBasket.Items.FirstOrDefault(x => x.Name == "Camembert"));
            shoppingBasket.Items.Count().Should().Be(1);
            shoppingBasket.Items.FirstOrDefault().Quantity.Should().Be(1);
            AfterTest();
        }

        //Add Items To Give Negative Quantity
        [Fact]
        public void AddItemsToGiveNegativeQuantity()
        {
            BeforeTest();
            var item1 = new Cheddar() as IShoppingItem;
            try
            {
                shoppingBasket.AddItem(item1, 1);
                shoppingBasket.Items.FirstOrDefault().Quantity.Should().Be(1);
                shoppingBasket.AddItem(item1, -5);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType(typeof(ArgumentOutOfRangeException));
            }
            AfterTest();
        }

        //Add Item With Negative Quantity
        [Fact]
        public void AddItemWithNegativeQuantity()
        {
            BeforeTest();
            var item1 = new Cheddar() as IShoppingItem;
            try
            {
                shoppingBasket.AddItem(item1, -5);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType(typeof(ArgumentOutOfRangeException));
            }
            AfterTest();
        }
    }
}
