using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Shopist.pageObjects
{
    public class StockOut
    {
        private IWebDriver driver;
        public StockOut(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            //this refers to current class objects
        }

        
        [FindsBy(How = How.XPath, Using = "//div[@class='serif'][normalize-space()='Chairs']")]
        //[FindsBy(How = How.XPath, Using = "//div[@class='jumbotron-box']//div[contains(text(),'Shop now')]")]
        private IWebElement shopBtn;

        [FindsBy(How = How.CssSelector, Using = "img[src='/_nuxt/img/4.ede59fc.jpg']")]
        private IWebElement itemLt;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-title']")]
        private IWebElement modalTil;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-button']")]
        private IWebElement modBtn;

       
        public IWebElement shopButton()
        {
            return shopBtn;
        }
        public IWebElement itemList()
        {
            return itemLt;
        }

        public IWebElement modalTitle()
        {
            return modalTil;
        }

        public IWebElement modalButton()
        {
            return modBtn;
        }

        public void validCheck()
        {
            shopButton().Click();
            itemList().Click();
            Thread.Sleep(1000);
            modalButton().Click();
            Thread.Sleep(1000);

        }
    }
}

