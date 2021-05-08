using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class SeleniumTests
    {
        
        private const string ChromeBrowser = "chrome";
        private const string FirefoxBrowser = "firefox";

        private IWebDriver driver;

        [DataTestMethod]
        [DataRow(ChromeBrowser)]
        [DataRow(FirefoxBrowser)]

        [TestMethod]
        public void SimpleTest(String browser)
        {
            if(browser.Equals(ChromeBrowser))
            {
                driver = new ChromeDriver();
            } else
            {
                driver = new FirefoxDriver();
            }

            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

            driver.Url = "https://seleniumtest222.azurewebsites.net/";

            Thread.Sleep(1000);

            var element = driver.FindElement(By.LinkText("About"));
            element.Click();

            Thread.Sleep(1000);

            Assert.IsTrue(driver.Url.Equals(@"https://seleniumtest222.azurewebsites.net/Home/About"));

            driver.Close();
            Thread.Sleep(1000);
            driver.Quit();
            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
