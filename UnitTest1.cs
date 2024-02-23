using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace J_E_Assessment
{
    [TestClass]
    public class UnitTest1
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Login
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(3000);

            // Add item to cart
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            Thread.Sleep(3000);

            // Proceed to checkout
            driver.FindElement(By.Id("checkout")).Click();
            Thread.Sleep(3000);

            // Fill checkout information
            driver.FindElement(By.Id("first-name")).SendKeys("Irene");
            driver.FindElement(By.Id("last-name")).SendKeys("Emeshili");
            driver.FindElement(By.Id("postal-code")).SendKeys("900108");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("continue")).Click();

            // Complete order
            Thread.Sleep(3000);
            driver.FindElement(By.Id("finish")).Click();

            // Verify order completion
            Assert.IsTrue(wait.Until(d => d.FindElement(By.ClassName("complete-header")).Displayed), "Order completion message not found.");

            // Return to products page
            Thread.Sleep(3000);
            driver.FindElement(By.Id("back-to-products")).Click();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
