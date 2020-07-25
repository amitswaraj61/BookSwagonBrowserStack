
using BookSwagon.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon
{

    [TestFixture("single", "chrome")]

    [Parallelizable]
  public class BookSwagonTest : Base
    {
        Credentials credentails = new Credentials();
        public BookSwagonTest(string profile, string environment) : base(profile, environment) { }

        [Test,Order(1)]
        public void ValidLogin()
        {
            driver.Url = ConfigurationManager.AppSettings["URL"];
            Login login = new Login(driver);
            login.LoginToBookSwagaon(credentails.email, credentails.password);
            string actualResult = driver.Url;
            string expectedResult = "https://www.bookswagon.com/myaccount.aspx";
            Assert.AreEqual(expectedResult, actualResult);
           
        }
        [Test, Order(2)]
        public void SearchBookTest()
        {
            
            Search search = new Search(driver);
            search.SearchBook();
            string url = "https://www.bookswagon.com/search-books/mahabharata";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
           
        }
        [Test, Order(3)]
        public void BuyBookTest()
        {
           
            SearchHomePage search = new SearchHomePage(driver);
            search.PlaceOrderBook();
            string url = "https://www.bookswagon.com/checkout-login";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
          
        }
        [Test, Order(4)]
        public void ShippingAddressTest()
        {
           
            ShippingAddess address = new ShippingAddess(driver);
            address.ShippingAddessData();
            string url = "https://www.bookswagon.com/viewshoppingcart.aspx";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
           
        }
        [Test, Order(5)]
        public void ReviewOderTest()
        {
           
            ReviewOrder review = new ReviewOrder(driver);
            review.ReviewOrderCheck();
            string url = "https://www.bookswagon.com/checkout.aspx";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
          
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            
            Logout logout = new Logout(driver);
            logout.LogoutToBookSwagaon();
            string url = "https://www.bookswagon.com/login";
            string actual = driver.Url;
            Assert.AreEqual(url, actual);
           
        }
    }
}

