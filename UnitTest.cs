using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace J_E_Assessment
{
    [TestClass]
    public class UnitTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Login
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("login-button")).Click();

            // Verify login successful
            Assert.IsTrue(driver.FindElement(By.ClassName("inventory_list")).Displayed, "Login unsuccessful");

            // Select a T-shirt
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"item_1_title_link\"]/div")).Click();

            // Verify T-shirt details page displayed
            Assert.IsTrue(driver.FindElement(By.ClassName("inventory_details_name")).Displayed, "T-shirt details page not displayed");

            // Add T-shirt to cart
            Thread.Sleep(2000);
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();

            // Verify T-shirt added to cart
            Assert.IsTrue(driver.FindElement(By.ClassName("shopping_cart_badge")).Displayed, "T-shirt not added to cart");

            // Navigate to cart
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            Thread.Sleep(2000);

            // Verify cart page displayed
            Assert.IsTrue(driver.FindElement(By.ClassName("cart_list")).Displayed, "Cart page not displayed");

            // Proceed to checkout
            driver.FindElement(By.Id("checkout")).Click();

            // Fill checkout information
            driver.FindElement(By.Id("first-name")).SendKeys("Irene");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("last-name")).SendKeys("Emeshili");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("postal-code")).SendKeys("900108");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("continue")).Click();

            // Complete order
            Thread.Sleep(2000);
            driver.FindElement(By.Id("finish")).Click();

            // Verify order completion
            Assert.IsTrue(driver.FindElement(By.ClassName("complete-header")).Displayed, "Order completion message not found");

            // Return to products page
            Thread.Sleep(2000);
            driver.FindElement(By.Id("back-to-products")).Click();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
