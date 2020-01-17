using FluentAssertions;
using ShoppingBasket;
using ShoppingBasket.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class TotalsTests : TestSetup
    {
        //After adding a single item to an empty basket, both the subtotal of the item and basket should equal the items unit price
        [Fact]
        public void AddSingleItemSubtotalAndTotalOfItemAndBasketMatch()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item,1);
            shoppingBasket.SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Total.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Items.FirstOrDefault().SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Items.FirstOrDefault().Total.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            AfterTest();
        }

        //After adding a single item(with a NoTax rule) to an empty basket, both the tax of the item and the basket should equal 0 and both the subtotal of the item and basket should equal the items unit price
        [Fact]
        public void AddSingleItemSubtotalAndTotalOfItemAndBasketMatchAndTax0ForNoTaxRule()
        {
            BeforeTest();
            var item = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(item, 1);
            shoppingBasket.SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Total.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Tax.Should().Be(0m);
            shoppingBasket.Items.FirstOrDefault().SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Items.FirstOrDefault().Total.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Items.FirstOrDefault().Tax.Should().Be(0m);
            AfterTest();
        }

        //After adding two items with different quantities(both with a NoTax rule) to an empty basket, both the tax of the item and the basket should equal 0, 
        //THIS IS WRONG?!?! - both the subtotal and the total of the item and basket should equal the items unit price
        [Fact]
        public void AddMultipleItemsWithNoTaxRuleSubtotalAndTotalOfItemAndBasketMatchAndTax0ForNoTaxRule()
        {
            BeforeTest();
            var cheddar = new Cheddar() as IShoppingItem;
            shoppingBasket.AddItem(cheddar, 1);
            var brie = new Brie() as IShoppingItem;
            shoppingBasket.AddItem(brie, 10);
            shoppingBasket.SubTotal.Should().Be(105m);
            shoppingBasket.Total.Should().Be(105m);
            shoppingBasket.Tax.Should().Be(0m);
            foreach(var item in shoppingBasket.Items)
            {
                item.SubTotal.Should().Be(item.UnitPrice * item.Quantity);  //Not what is asked for, but is correct
                item.Total.Should().Be(item.UnitPrice * item.Quantity);     //Not what is asked for, but is correct
                item.Tax.Should().Be(0m);
            }
            AfterTest();
        }
    }
}
