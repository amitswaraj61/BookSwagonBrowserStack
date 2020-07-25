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
    class Logout
    {
        public IWebDriver driver;
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]

        public IWebElement logoutButton;

       public void LogoutToBookSwagaon()
        {

            logoutButton.Click();
            Thread.Sleep(2000);
        }
    }
}
