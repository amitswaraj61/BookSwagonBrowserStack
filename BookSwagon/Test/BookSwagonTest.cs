using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSwagon.Pages;
using AventStack.ExtentReports;
using BookSwagon.Email;
using AventStack.ExtentReports.MarkupUtils;
using System.Threading;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework.Interfaces;

namespace BookSwagon.Test
{
    [TestFixture]
    public class BookSwagonTest : Base
    {
        Credentials credentails = new Credentials();
        public static ExtentReports extent = null;
        public static ExtentTest test = null;
        /*


       [OneTimeSetUp]
       public void ExtentReport()
       {
           extent = new ExtentReports();
           var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Kis\source\repos\BookSwagon\BookSwagon\Report\index.html");
           extent.AttachReporter(htmlReporter);
           String hostname = Dns.GetHostName();
           OperatingSystem os = Environment.OSVersion;
           extent.AddSystemInfo("operating system", hostname);
           extent.AddSystemInfo("Host name", hostname);
           extent.AddSystemInfo("Browser", "Google Chrome");

       }
       [TearDown]
       public void ExtentClose()
       {
           test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
           var status = TestContext.CurrentContext.Result.Outcome.Status;
           var error = TestContext.CurrentContext.Result.Message;
           Status status1;
           if (TestStatus.Failed==status)
           {
               test.Log(Status.Fail, "Test Failed");
               string path = Screenshot.Capture(driver, "Login Failed");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Fail, "Test Failed");
           }
           else
           {
               string path = Screenshot.Capture(driver, (TestContext.CurrentContext.Test.Name));
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Test pass");
           }
           extent.Flush();
       }

       [Test, Order(1)]
       public void ValidLogin()
       {
           try
           {

               test = extent.CreateTest("LoginTest").Info("Test Started");
               Login login = new Login(driver);
               test.Log(Status.Info, "Chrome Browser Launched");
               login.LoginToBookSwagaon(credentails.email, credentails.password);
               test.Log(Status.Info, "Valid email and password is entered");
               string actualResult = driver.Url;
               test.Log(Status.Info, "get the URl of Bookswagon");
               string expectedResult = "https://www.bookswagon.com/myaccount.aspx";
               Assert.AreEqual(expectedResult,actualResult);

          }
           catch (Exception exception)
           {




                   SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);


              throw exception;
           }
       }
       [Test, Order(2)]
       public void SearchBookTest()
       {
           try
           {
               test = extent.CreateTest("SearchBook").Info("Test Started");
               Search search = new Search(driver);
               test.Log(Status.Info, "Books to be Searched");
               search.SearchBook();
               string url = "https://www.bookswagon.com/search-books/mahabharata";
               string actual = driver.Url;
               Assert.AreEqual(url, actual);
               string path = Screenshot.Capture(driver, "Search Book");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Books successFully searched");
           }
           catch (Exception exception)
           {
               test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
               string path = Screenshot.Capture(driver, "Searched Failed");
               test.AddScreenCaptureFromPath(path);
               SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
               throw;
           }
       }
       [Test, Order(3)]
       public void BuyBookTest()
       {
           try
           {
               test = extent.CreateTest("BuyNowBook").Info("Test Started");
               SearchHomePage search = new SearchHomePage(driver);
               search.PlaceOrderBook();
               test.Log(Status.Info, "placed order successfull");
               string url = "https://www.bookswagon.com/checkout-login";
               string actual = driver.Url;
               Assert.AreEqual(url, actual);
               string path = Screenshot.Capture(driver, "Buy Book Test passed");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Placed successFully");
           }
           catch (Exception exception)
           {
               test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
               string path = Screenshot.Capture(driver, "Buy Book test Failed");
               test.AddScreenCaptureFromPath(path);
               SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
               throw;
           }
       }
       [Test, Order(4)]
       public void ShippingAddressTest()
       {
           try
           {
               test = extent.CreateTest("Shipping Address").Info("Test Started");
               ShippingAddess address = new ShippingAddess(driver);
               address.ShippingAddessData();
               string url = "https://www.bookswagon.com/viewshoppingcart.aspx";
               string actual = driver.Url;
               Assert.AreEqual(url, actual);
               string path = Screenshot.Capture(driver, "shipping Address passed");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Shipping Address successfully entered");
           }
           catch (Exception exception)
           {
               test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
               string path = Screenshot.Capture(driver, "shipping address Failed");
               test.AddScreenCaptureFromPath(path);
               SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
               throw;
           }
       }
       [Test, Order(5)]
       public void ReviewOderTest()
       {
           try
           {
               test = extent.CreateTest("Review Oder").Info("Test Started");
               ReviewOrder review = new ReviewOrder(driver);
               review.ReviewOrderCheck();
               string url = "https://www.bookswagon.com/checkout.aspx";
               string actual = driver.Url;
               Assert.AreEqual(url, actual);
               string path = Screenshot.Capture(driver, "Review order");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Review order successfully passed");
           }
           catch (Exception exception)
           {
               test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
               string path = Screenshot.Capture(driver, "Review order Failed");
               test.AddScreenCaptureFromPath(path);
               SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
               throw;
           }
       }
       [Test, Order(6)]
       public void LogoutTest()
       {
           try
           {
               test = extent.CreateTest("Logout").Info("Test Started");
               Logout logout = new Logout(driver);
               logout.LogoutToBookSwagaon();
               string url = "https://www.bookswagon.com/login";
               string actual = driver.Url;
               Assert.AreEqual(url, actual);
               string path = Screenshot.Capture(driver, "Logout");
               test.AddScreenCaptureFromPath(path);
               test.Log(Status.Pass, "Logout Successfully");
           }
           catch (Exception exception)
           {
               test.Fail(MarkupHelper.CreateLabel("Test Failed", ExtentColor.Red));
               string path = Screenshot.Capture(driver, "Logout Failed");
               test.AddScreenCaptureFromPath(path);
               SendEmailMain.SendEmail(exception.Message.Trim(), exception.StackTrace);
               throw;
           }
       }*/
        [OneTimeSetUp]

    }
}
            
