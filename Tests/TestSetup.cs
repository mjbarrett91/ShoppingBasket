using ShoppingBasket.Interfaces;

namespace Tests
{
    public class TestSetup
    {
        internal IShoppingBasket shoppingBasket;

        public void BeforeTest()
        {
            shoppingBasket = new ShoppingBasket.ShoppingBasket() as IShoppingBasket;
        }

        public void AfterTest()
        {
        }
    }
}
