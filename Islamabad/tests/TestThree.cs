using Shopist.pageObjects;
using Shopist.utilities;

namespace Shopist.tests
{
    public class TestThree : Base
    {
        [Test]
        public void RemovingItem()
        {
            CheckOut checkOutRemove = new CheckOut(getDriver());
            checkOutRemove.RemoveItemFromCart();
        }
    }
}
