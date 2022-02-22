using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class LoginSelenium
    {
        [TestMethod]
        public void Login()
        {

            var chromeOption = new ChromeOptions();
            chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOption))
            {
                driver.Navigate().GoToUrl("https://www.google.com/");

                IWebElement query = driver.FindElement(By.Name("q"));

                query.SendKeys("Cheese");

                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));

                wait.Until(d => d.Title.StartsWith("Cheese", StringComparison.Ordinal));

                Assert.AreEqual(driver.Title , "Cheese - Google Search");
            }
        }

    }
}
