using Shopist.pageObjects;
using Shopist.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
