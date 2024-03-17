using Shopist.pageObjects;
using Shopist.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

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