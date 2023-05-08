using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace SeleniumTest_WebSell
{
    [TestClass]
    public class TestWebAgent
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver = new ChromeDriver();
        }

        //[TestMethod]
        [DataTestMethod]
        [DataRow("phanhuy", "phanhuy", "https://localhost:44361/")]
        [DataRow("tdtu", "tdtu", "https://localhost:44361/")]
        [DataRow("final", "final", "https://localhost:44361/")]
        [DataRow("wrong", "wrong", "https://localhost:44361/Login/Authen")]
        [DataRow("test", "test", "https://localhost:44361/Login/Authen")]
        public void TestLogin(string name,string pwd,string expected)
        {
            
            By username = By.Name("Username");
            By password = By.Name("Password");
            By submit = By.XPath("/html/body/div[2]/section/div/div/div[2]/form/table/tbody/tr[3]/td[2]/button");

            webDriver.Navigate().GoToUrl("https://localhost:44361/Login/Login");
            webDriver.FindElement(username).SendKeys(name);
            webDriver.FindElement(password).SendKeys(pwd);
            webDriver.FindElement(submit).Click();
            //Thread.Sleep(6000);
            Assert.AreEqual(expected,webDriver.Url);

            //Thread.Sleep(1000);
            webDriver.Quit();
        }
        [TestMethod]
        //[DataTestMethod]
        //[DataRow("phanhuy", "phanhuy", "https://localhost:44361/")]
        //[DataRow("tdtu", "tdtu", "https://localhost:44361/")]
        //[DataRow("final", "final", "https://localhost:44361/")]
        //[DataRow("wrong", "wrong", "https://localhost:44361/Login/Authen")]
        //[DataRow("test", "test", "https://localhost:44361/Login/Authen")]
        public void TestCheckOut_Success_Cash()
        {

            By username = By.Name("Username");
            By password = By.Name("Password");
            By submit = By.XPath("/html/body/div[2]/section/div/div/div[2]/form/table/tbody/tr[3]/td[2]/button");

            webDriver.Navigate().GoToUrl("https://localhost:44361/Login/Login");
            webDriver.FindElement(username).SendKeys("phanhuy");
            webDriver.FindElement(password).SendKeys("phanhuy");
            webDriver.FindElement(submit).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44361/ShoppingCart/ShowToCart");

            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[2]/input")).Click();
            Thread.Sleep(1000);

            Assert.AreEqual("https://localhost:44361/ShoppingCart/Checkout_Success", webDriver.Url);

            webDriver.Quit();
        }
        [TestMethod]
        public void TestCheckOut_Success_VNPay()
        {

            By username = By.Name("Username");
            By password = By.Name("Password");
            By submit = By.XPath("/html/body/div[2]/section/div/div/div[2]/form/table/tbody/tr[3]/td[2]/button");

            webDriver.Navigate().GoToUrl("https://localhost:44361/Login/Login");
            webDriver.FindElement(username).SendKeys("phanhuy");
            webDriver.FindElement(password).SendKeys("phanhuy");
            webDriver.FindElement(submit).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44361/ShoppingCart/ShowToCart");
            Thread.Sleep(1000);
            //webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select"))
            //var comboBox = webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select"));
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select/option[2]")).Click();

           
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[2]/input")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"accordionList\"]/div[2]/div[1]/div")).Click();
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

            Assert.AreEqual("https://localhost:44361/ShoppingCart/Checkout_Success", webDriver.Url);

            webDriver.Quit();
        }

        [TestMethod]
        public void TestCheckOut_Fail_VNPay()
        {

            By username = By.Name("Username");
            By password = By.Name("Password");
            By submit = By.XPath("/html/body/div[2]/section/div/div/div[2]/form/table/tbody/tr[3]/td[2]/button");

            webDriver.Navigate().GoToUrl("https://localhost:44361/Login/Login");
            webDriver.FindElement(username).SendKeys("phanhuy");
            webDriver.FindElement(password).SendKeys("phanhuy");
            webDriver.FindElement(submit).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44361/ShoppingCart/ShowToCart");
            Thread.Sleep(1000);
            //webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select"))
            //var comboBox = webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select"));
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[1]/select/option[2]")).Click();


            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[2]/input")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"accordionList\"]/div[2]/div[1]/div")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"NCB\"]/div")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id=\"cardVerify\"]/div/div[3]/div[2]/div[1]/a")).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id=\"modalCancelPayment\"]/div/div/div[3]/div/div[2]/a")).Click();

            Thread.Sleep(7000);

            Assert.AreEqual("https://localhost:44361/ShoppingCart/Checkout_Fail", webDriver.Url);

            webDriver.Quit();
        }
        [TestMethod]
        public void TestCheckOut_Fail()
        {

            By username = By.Name("Username");
            By password = By.Name("Password");
            By submit = By.XPath("/html/body/div[2]/section/div/div/div[2]/form/table/tbody/tr[3]/td[2]/button");

            webDriver.Navigate().GoToUrl("https://localhost:44361/Login/Login");
            webDriver.FindElement(username).SendKeys("phanhuy");
            webDriver.FindElement(password).SendKeys("wrong");
            webDriver.FindElement(submit).Click();
            webDriver.Navigate().GoToUrl("https://localhost:44361");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/a/img")).Click();
            Thread.Sleep(1000);
            webDriver.Navigate().GoToUrl("https://localhost:44361/ShoppingCart/ShowToCart");

            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[2]/table/tfoot/tr[2]/td[2]/input")).Click();
            Thread.Sleep(1000);

            Assert.AreEqual("https://localhost:44361/ShoppingCart/Checkout_Fail", webDriver.Url);

            webDriver.Quit();
        }



        [TestCleanup]
        public void TestCleanup()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }
    }
}
