using Shopist.pageObjects;
using Shopist.utilities;

namespace Shopist.tests
{
    public class TestTwo : Base
    {
        [Test, Category("Smoke")]
        public void ItemOutStock()
        {

            StockOut checkStock = new StockOut(getDriver());
            checkStock.validCheck();
        }

        [Test, Category("Smoke")]
        public void CheckOutProcess()
        {
            CheckOut checkout = new CheckOut(getDriver());
            checkout.AddingItemToCart();
            checkout.ContinueButton().Click();

        }

        [Test, Category("Smoke")]

        public void IncrementItem()
        {
            CheckOut checkOutIncrement = new CheckOut(getDriver());
            checkOutIncrement.IncrementItem();

        }

        [Test, Category("Smoke")]
        public void DecrementItem()
        {
            CheckOut checkOutDecrement = new CheckOut(getDriver());
            checkOutDecrement.DecrementItem();

        }
    }
}