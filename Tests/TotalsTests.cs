using FluentAssertions;
using ShoppingBasket;
using ShoppingBasket.Interfaces;
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
            shoppingBasket.AddItem(item, 1);
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
            foreach (var item in shoppingBasket.Items)
            {
                item.SubTotal.Should().Be(item.UnitPrice * item.Quantity);  //Not what is asked for, but is correct
                item.Total.Should().Be(item.UnitPrice * item.Quantity);     //Not what is asked for, but is correct
                item.Tax.Should().Be(0m);
            }
            AfterTest();
        }

        // Tax is calculated on Item and in Basket
        [Fact]
        public void AddSingleItemTaxIsCalulatedInBasketAndItem()
        {
            BeforeTest();
            var item = new Camembert() as IShoppingItem;
            shoppingBasket.AddItem(item, 1);
            shoppingBasket.SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Tax.Should().Be(2m);
            shoppingBasket.Total.Should().Be(22m);
            shoppingBasket.Items.FirstOrDefault().SubTotal.Should().Be(shoppingBasket.Items.FirstOrDefault().UnitPrice);
            shoppingBasket.Items.FirstOrDefault().Tax.Should().Be(2m);
            shoppingBasket.Items.FirstOrDefault().Total.Should().Be(22);
            AfterTest();
        }

        // Multiple quantity Tax is calculated on Item and in Basket, Basket total higher
        [Fact]
        public void AddMultipleItemsTaxIsCalulatedBasketAndItemTotalsDifferent()
        {
            BeforeTest();
            var cammbert = new Camembert() as IShoppingItem;
            var brie = new Brie() as IShoppingItem;
            shoppingBasket.AddItem(cammbert, 10);
            shoppingBasket.Items.FirstOrDefault().SubTotal.Should().Be(200m);
            shoppingBasket.Items.FirstOrDefault().Tax.Should().Be(20m);
            shoppingBasket.Items.FirstOrDefault().Total.Should().Be(220m);
            shoppingBasket.AddItem(brie, 10);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == brie.Id).SubTotal.Should().Be(100m);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == brie.Id).Tax.Should().Be(0m);
            shoppingBasket.Items.FirstOrDefault(x => x.Id == brie.Id).Total.Should().Be(100m);
            shoppingBasket.SubTotal.Should().Be(300m);
            shoppingBasket.Tax.Should().Be(20m);
            shoppingBasket.Total.Should().Be(320);

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
            shoppingBasket.Total.Should().Be(0m);
            AfterTest();
        }
    }
}
