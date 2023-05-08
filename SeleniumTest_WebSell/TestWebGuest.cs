using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SeleniumTest_WebSell
{
    [TestClass]
    public class TestWebGuest
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver = new ChromeDriver();
        }
        public void TestCleanup()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }
        [TestMethod]
        public void TestCheckOut_Cash()
        {

            webDriver.Navigate().GoToUrl("https://localhost:44324/");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[6]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44324/ShoppingCart/ShowToCart");

            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Name")).SendKeys("Test");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Email")).SendKeys("Test@mail.com");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Phone")).SendKeys("089999999");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Address")).SendKeys("19 Nguyen Huu Tho");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[6]/div/button")).Click();
            Thread.Sleep(3000);

            Assert.AreEqual("https://localhost:44324/ShoppingCart/Checkout_Success", webDriver.Url);
            webDriver.Quit();
        }
        [TestMethod]
        public void TestCheckOut_VNPay()
        {

            webDriver.Navigate().GoToUrl("https://localhost:44324/");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[6]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44324/ShoppingCart/ShowToCart");

            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Name")).SendKeys("Test");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Email")).SendKeys("Test@mail.com");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Phone")).SendKeys("089999999");
            Thread.Sleep(1000);
            webDriver.FindElement(By.Name("Address")).SendKeys("19 Nguyen Huu Tho");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[5]/div/select/option[2]")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[6]/div/button")).Click();
            Thread.Sleep(3000);

            webDriver.FindElement(By.XPath("//*[@id=\"accordionList\"]/div[2]/div[1]")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"NCB\"]/div")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"card_number_mask\"]")).SendKeys("9704198526191432198");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"cardHolder\"]")).SendKeys("NGUYEN VAN A");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"cardDate\"]")).SendKeys("0715");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"btnContinue\"]")).Click();
            Thread.Sleep(7000);
            webDriver.FindElement(By.XPath("//*[@id=\"otpvalue\"]")).SendKeys("123456");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"btnConfirm\"]")).Click();
            Thread.Sleep(7000);

            Assert.AreEqual("https://localhost:44324/ShoppingCart/Checkout_Success", webDriver.Url);
            webDriver.Quit();
        }
    }
}
