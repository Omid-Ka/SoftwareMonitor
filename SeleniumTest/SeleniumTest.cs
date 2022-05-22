using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class SeleniumTest
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("UserName"));
                
                query.SendKeys("Omid");

                query = driver.FindElement(By.Name("Password"));

                query.SendKeys("Omid3883");


                query = driver.FindElement(By.XPath("/html/body/section/div/div[2]/div/div/form/div[4]/button"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[1]/div[2]/div[3]/i"));
                query.Click();



                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[1]/div[2]/div[3]/ul/li[3]/a"));
                query.Click();

                //wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));

                //Thread.Sleep(2000);
                Thread.Sleep(4000);

                Assert.AreEqual(driver.Title , "ورود");
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
                

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/ul/li[1]/a"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/a"));
                query.Click();

                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);


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


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");
            }
        }

        
        [TestMethod]
        public void UserList()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/ul/li[2]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("Name"));

                query.SendKeys("تست");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("Family"));

                query.SendKeys("1تست");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("NationalCode"));

                query.SendKeys("1234");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("Email"));

                query.SendKeys("Test@mail.com");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("UserName"));

                query.SendKeys("Test");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("Password"));

                query.SendKeys("1234");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("MobileNo"));

                query.SendKeys("0956456");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("LocalTel"));

                query.SendKeys("01111111");


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("PersonnelCode"));

                query.SendKeys("3333");


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div[1]/div/div/div/button"));

                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div[1]/div/div/div/div/ul/li[2]/a"));

                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div[2]/div/div/div/button"));

                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div[2]/div/div/div/div/ul/li[2]/a"));

                query.Click();




                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[5]/div/input"));

                query.Click();


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }

        
        [TestMethod]
        public void UsersGroup()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[2]/ul/li[4]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.Name("GroupName"));

                query.SendKeys("تست");


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/div[2]/label/span"));


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div/input"));

                query.Click();

                Thread.Sleep(2000);
                

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }

        [TestMethod]
        public void ProjectLookups()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/ul/li[1]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/input"));

                query.SendKeys("تست");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/input"));

                query.SendKeys("توضیحات تست");


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/div[1]/div/div/div/button"));
                query.Click();
                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/div[1]/div/div/div/div/ul/li[2]/a"));
                query.Click();


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/div[2]/div/div/input"));

                query.SendKeys("برنامه نویس");


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div/input"));

                query.Click();


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }


        [TestMethod]
        public void ProjectVersion()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/ul/li[2]/a"));
                query.Click();


                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/a"));
                query.Click();

                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/div/ul/li[3]/a/span[1]"));
                query.Click();



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/div/button"));

                query.Click();

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/div/div/ul/li[2]/a"));

                query.Click();



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[3]/div/div/input"));

                Random rand = new Random();
                var version = rand.Next(1, 20);

                query.SendKeys("3.4" + version.ToString());


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div/input"));
                query.Click();


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }

        
        [TestMethod]
        public void ProjectLists()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[3]/ul/li[3]/a"));
                query.Click();


                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/a"));
                query.Click();

                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/input"));
                query.SendKeys("Selenium");

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/input"));
                query.SendKeys("SeleniumDescription");

                


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div/input"));
                query.Click();


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }


        [TestMethod]
        public void DocReview()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/ul/li[1]/a"));
                query.Click();


                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/a"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div/div/div/div/div/ul/li[2]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[2]/div/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[2]/div/div/div/div/div/ul/li[8]/a"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[1]/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[1]/div/div/div/div/ul/li[3]/a/span[1]"));
                query.Click();


                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[2]/div/div/select"));
                query.Click();

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[2]/div/div/select/option[2]"));
                query.Click();

                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[4]/div/div/div/input"));
                query.SendKeys("Selenium Is a Good Test Tools");

                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[3]/ul/li[3]/a"));
                query.Click();

                Thread.Sleep(2000);

                //Tests

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[2]/div[1]/div[1]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[2]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - نمودار توالی");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[4]/div[1]/div[2]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[4]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - نمودار فعالیت");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[6]/div[1]/div[1]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[6]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - نمودار کاربرد");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[8]/div[1]/div[2]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[8]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - نمودار کلاس");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[10]/div[1]/div[1]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[10]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - ماژول ها");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[12]/div[1]/div[2]/div/input"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[12]/div[3]/div/div/input"));
                query.SendKeys("سلنیوم - شرح فعالیت");

                Thread.Sleep(2000);
                
                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[3]/ul/li[4]/a"));
                query.Click();
                
                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }



        [TestMethod]
        public void CodeReview()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/ul/li[2]/a"));
                query.Click();


                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/a")); 
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div[1]/div/div/div/button"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div[1]/div/div/div/div/ul/li[3]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div[2]/div/div/select"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[1]/div[2]/div/div/select/option[2]"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[2]/div[1]/div/div/input"));
                query.SendKeys("2500");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[2]/div[2]/div/div/input"));
                query.SendKeys("500");
                
                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[1]/div/div/input"));
                query.SendKeys("500");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div[2]/div/div/input"));
                query.SendKeys("500");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[4]/div[1]/div/div/input"));
                query.SendKeys("500");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[4]/div[2]/div/div/input"));
                query.SendKeys("500");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[5]/div/div/div/input"));
                query.SendKeys("پیشنهادات خوب");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[1]/div[6]/div/div/div/input"));
                query.SendKeys("نظرات بهتر");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[3]/ul/li[3]/a"));
                query.Click();
                

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[2]/div/div[3]/div/input"));
                query.SendKeys("1");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[2]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - کدها بی استفاده");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[3]/div/div[3]/div/input"));
                query.SendKeys("3");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[3]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - کامنت گذاری");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[4]/div/div[3]/div/input"));
                query.SendKeys("3");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[4]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - نامگذاری کد");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - مدیریت استثناء");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[7]/div/div[3]/div/input"));
                query.SendKeys("3");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[7]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - رعایت اصول شی گرایی");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[9]/div/div[3]/div/input"));
                query.SendKeys("5");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[9]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - ورودی و خروجی توابع");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[10]/div/div[3]/div/input"));
                query.SendKeys("5");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[10]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - رمزگذاری کلمات عبور یا Session");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[12]/div/div[3]/div/input"));
                query.SendKeys("5");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[12]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - میزان مصرف CPU");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[13]/div/div[3]/div/input"));
                query.SendKeys("3");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[13]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - میزان مصرف RAM");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[14]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[14]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - متغییر و نوع داده");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[16]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[16]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - Maintainability");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[17]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[17]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - Cyclomatic");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[18]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[18]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - Class Coupling");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[20]/div/div[3]/div/input"));
                query.SendKeys("4");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/form/div[2]/div[20]/div/div[5]/div/input"));
                query.SendKeys("سلنیوم - Warning");

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[3]/ul/li[4]/a"));
                query.Click();


                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }



        [TestMethod]
        public void LoadAndStressTest()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[4]/ul/li[3]/a"));
                query.Click();


                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/a"));
                query.Click();
                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/button"));
                query.Click();
                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[1]/div/div/div/div/ul/li[3]/a"));
                query.Click();
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/select"));
                query.Click();
                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[2]/div/div/select/option[2]"));
                query.Click();
                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[3]/div/div/div/button"));
                query.Click();
                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[1]/div[3]/div/div/div/div/ul/li[4]/a"));
                query.Click();
                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div[1]/div/div/input"));
                query.SendKeys("25000");
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div[2]/div/div/input"));
                query.SendKeys("24000");
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[2]/div[3]/div/div/input"));
                query.SendKeys("1000");
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div[1]/div/div/input"));
                query.SendKeys("356");
                Thread.Sleep(2000);





                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div[2]/div/div/input"));
                query.SendKeys("5324568");
                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[3]/div[3]/div/div/input"));
                query.SendKeys("1522");
                Thread.Sleep(2000);




                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[4]/div/div/div/input"));
                query.SendKeys("سلنیوم - آزمون بار");
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/form/div[5]/div/input"));
                query.Click();

                

                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }




        [TestMethod]
        public void Reports()
        {
            var chromeOption = new ChromeOptions();
            //chromeOption.AddArgument("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOption))
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

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[5]/a"));
                query.Click();

                Thread.Sleep(2000);

                query = driver.FindElement(By.XPath("/html/body/section[1]/aside/div[2]/div/ul/li[5]/ul/li/a"));
                query.Click();
                
                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/div[1]/div[1]/div/div/div/button"));
                query.Click();
                Thread.Sleep(2000);
                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div/ul/li[2]/a/span[1]"));
                query.Click();
                Thread.Sleep(2000);



                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/div[1]/div[2]/div/div/select"));
                query.Click();
                Thread.Sleep(2000);
                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/div[1]/div[2]/div/div/select/option[2]"));
                query.Click();
                Thread.Sleep(2000);


                query = driver.FindElement(By.XPath("/html/body/section[2]/div/div[1]/div[2]/div[2]/div[1]/div/a/span"));
                query.Click();


                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(110));

                Thread.Sleep(2000);

                Assert.AreEqual(driver.Title, "پایش سامانه");

            }
        }

    }
}
