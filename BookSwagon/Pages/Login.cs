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
  public class Login
    {
        public IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtEmail")]

        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtPassword")]

        public IWebElement Pass;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_btnLogin")]

        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='ac-container']//li[1]//a[1]")]
         public IWebElement validation;

        public void LoginToBookSwagaon(String email, String Password)
        {

            Email.SendKeys(email);
            Thread.Sleep(2000);
            Pass.SendKeys(Password);
            Thread.Sleep(2000);
            LoginButton.Click();
            Thread.Sleep(2000);
        }
        public string Validate()
        { return validation.Text; }
    }
}
