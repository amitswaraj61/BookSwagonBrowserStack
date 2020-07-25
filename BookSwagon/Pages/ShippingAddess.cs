using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;
using System.Configuration;

namespace BookSwagon.Pages
{
    class ShippingAddess
    {
        public IWebDriver driver;
        public ShippingAddess(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Continue')]")]

        public IWebElement continueButton;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewRecipientName")]

        public IWebElement receiptName;

        [FindsBy(How = How.XPath, Using = "//div[4]//div[2]//textarea[1]")]

        public IWebElement address;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ddlNewState")]

        public IWebElement state;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewCity")]

        public IWebElement city;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewPincode")]

        public IWebElement pinCode;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewMobile")]

        public IWebElement mobileNumber;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_imgSaveNew")]

        public IWebElement saveAndContinue;
        public void ShippingAddessData()
        {

            continueButton.Click();
            Thread.Sleep(2000);
            receiptName.Click();
            Thread.Sleep(2000);
            receiptName.SendKeys(ConfigurationManager.AppSettings["userName"]);
            Thread.Sleep(3000);
            address.Click();
            Thread.Sleep(3000);
            address.SendKeys(ConfigurationManager.AppSettings["Address"]);
            Thread.Sleep(3000);
            SelectElement selectState = new SelectElement(state);
            Thread.Sleep(3000);
            selectState.SelectByText(ConfigurationManager.AppSettings["state"]);
            Thread.Sleep(3000);
            city.Click();
            Thread.Sleep(3000);
            city.SendKeys(ConfigurationManager.AppSettings["city"]);
            Thread.Sleep(3000);
            pinCode.Click();
            Thread.Sleep(3000);
            pinCode.SendKeys(ConfigurationManager.AppSettings["pinCode"]);
            Thread.Sleep(1000);
            mobileNumber.Click();
            Thread.Sleep(3000);
            mobileNumber.SendKeys(ConfigurationManager.AppSettings["phoneNumber"]);
            Thread.Sleep(3000);
            saveAndContinue.Click();
            Thread.Sleep(3000);
           
        }
    }
}




