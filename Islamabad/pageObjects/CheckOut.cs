using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Shopist.pageObjects
{
    public class CheckOut
    {
        private IWebDriver driver;

        public CheckOut(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            //this refers to current class objects
        }

        //Pageobject Factory

        //[FindsBy(How = How.XPath, Using = "//div[@class='menu-item-large'][normalize-space()='Chairs']")]
        [FindsBy(How = How.XPath, Using = "//div[@class='serif'][normalize-space()='Chairs']")]
        private IWebElement ShopBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='purchase-button']")]
        private IWebElement AddtoCartBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[2]/div[1]/div[1]/a")]
        private IWebElement ItemSlt;

        [FindsBy(How = How.XPath, Using = "//*[@id='__layout']/div/div[1]/div[1]/div/div[2]/a[2]/div/div")]
        private IWebElement CartBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='checkout']")]
        private IWebElement CheckoutBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='continue-shopping']")]
        private IWebElement ContBtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='checkout-title']")]
        private IWebElement CheckTle;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"main\"]/section/div[2]/div[1]/div[3]/div/div/div/div[2]/div[1]/div[2]")]
        private IWebElement RemoveBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"main\"]/section/div[2]/div[1]/div[3]/div/div/div/div[2]/div[1]/div[1]/div[3]")]
        private IWebElement IncremBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"main\"]/section/div[2]/div[1]/div[3]/div/div/div/div[2]/div[1]/div[1]/div[1]")]
        private IWebElement DecremBtn;


        // Methods

        public IWebElement ShopButton()
        {
            return ShopBtn;                // Concept of Encapsulation
        }
        public IWebElement AddCart()
        {
            return AddtoCartBtn;                // Concept of Encapsulation
        }

        public IWebElement SelectItem()
        {
            return ItemSlt;                // Concept of Encapsulation
        }

        public IWebElement GoToCart()
        {
            return CartBtn;                // Concept of Encapsulation
        }

        public IWebElement GoToCheckOut()
        {
            return CheckoutBtn;                // Concept of Encapsulation
        }

        public IWebElement ContinueButton()
        {
            return ContBtn;                // Concept of Encapsulation
        }
        public IWebElement CheckOutTitle()
        {
            return CheckTle;                // Concept of Encapsulation
        }

        public IWebElement RemoveButton()
        {
            return RemoveBtn;                // Concept of Encapsulation
        }

        public IWebElement IncrementButton()
        {
            return IncremBtn;                // Concept of Encapsulation
        }

        public IWebElement DecrementButton()
        {
            return DecremBtn;                // Concept of Encapsulation
        }

        public void AddingItemToCart()
        {
            ShopButton().Click();
            SelectItem().Click();
            AddCart().Click();
            GoToCart().Click();
            GoToCheckOut().Click();
        }

        public void RemoveItemFromCart()
        {
            ShopButton().Click();
            SelectItem().Click();
            AddCart().Click();
            GoToCart().Click();
            RemoveButton().Click();
        }

        public void IncrementItem()
        {
            ShopButton().Click();
            SelectItem().Click();
            AddCart().Click();
            GoToCart().Click();
            IncrementButton().Click();
            GoToCheckOut().Click();
            ContinueButton().Click();

        }

        public void DecrementItem()
        {
            ShopButton().Click();
            SelectItem().Click();
            AddCart().Click();
            GoToCart().Click();
            DecrementButton().Click();

        }

    }
}

