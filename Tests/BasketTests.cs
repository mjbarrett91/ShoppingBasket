using FluentAssertions;
using ShoppingBasket.Interfaces;
using System.Linq;
using Xunit;

namespace Tests
{
    public class BasketTests
    {
        //* A newly constructed basket has 0 items in and totals that are all 0
        [Fact]
        public void NewBasketIsEmpty()
        {
            var basket = new ShoppingBasket.ShoppingBasket() as IShoppingBasket;
            basket.Items.Count().Should().Be(0);
            basket.SubTotal.Should().Be(0m);
            basket.Total.Should().Be(0m);
            basket.Tax.Should().Be(0m);
        }
    }
}
