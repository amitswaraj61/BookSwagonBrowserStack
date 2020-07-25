using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookSwagon.Pages
{
    class ReviewOrder
    {
        public IWebDriver driver;
        public ReviewOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_savecontinue")]

        public IWebElement saveAndContinue;

       public void ReviewOrderCheck()
        {
            saveAndContinue.Click();
            Thread.Sleep(2000);
        }
    }
}
