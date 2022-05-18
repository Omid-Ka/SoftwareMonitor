﻿using System;
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
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOption))
            {
                driver.Navigate().GoToUrl("http://192.168.164.43:8080/");

                IWebElement query = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div[1]/a"));
                query.Click();
                
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));

                wait.Until(d => d.Title.StartsWith("ورود", StringComparison.Ordinal));

                query = driver.FindElement(By.Name("UserName"));
                
                query.SendKeys("Omid");

                query = driver.FindElement(By.Name("Password"));

                query.SendKeys("Omid3883");


                query = driver.FindElement(By.XPath("/html/body/section/div/div[2]/div/div/form/div[4]/button"));
                query.Click();



                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));

                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));

                Assert.AreEqual(driver.Title , "پایش سامانه");
            }
        }


        [TestMethod]
        public void UserLookups()
        {

            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOption))
            {
                driver.Navigate().GoToUrl("http://192.168.164.43:8080/");

                IWebElement query = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div[1]/a"));
                query.Click();




                query = driver.FindElement(By.Name("UserName"));

                query.SendKeys("Omid");

                query = driver.FindElement(By.Name("Password"));

                query.SendKeys("Omid3883");


                query = driver.FindElement(By.XPath("/html/body/section/div/div[2]/div/div/form/div[4]/button"));
                query.Click();
                
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/a"));
                query.Click();

                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/ul/li[1]/a"));
                query.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/a"));
                query.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/button"));
                query.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/div/ul/li[3]/a/span[1]"));
                query.Click();



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/input"));

                query.SendKeys("SelTest");

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[3]/div/div/input"));

                query.SendKeys("For Selenium Test");



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/div/div/input"));

                query.SendKeys("10");


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div/input"));
                query.Click();



                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(110));

                wait.Until(d => d.Title.StartsWith("پایش سامانه", StringComparison.Ordinal));

                Assert.AreEqual(driver.Title, "پایش سامانه");
            }
        }

    }
}
