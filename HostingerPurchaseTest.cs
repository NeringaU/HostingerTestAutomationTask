using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HostingerTestAutomationTask

{
    public class HostingerPurchaseTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //set the path to the ChromeDriver executable
            var driverPath = "C:\\Users\\Neringa\\source\\repos\\HostingerTestAutomationTask\\HostingerTestAutomationTask\\bin\\Debug";

            //Initialize the ChromeDriver
            driver = new ChromeDriver(driverPath);
        }

        [Test]
        public void PurchaseHostingPlan()
        {
            //Visit hostinger.com
            driver.Navigate().GoToUrl("https://www.hostinger.com");
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"layout\"]/div/div/div/div/div/div/button[3]")).Click();

            //Find and Click on the element
            driver.FindElement(By.Id("hgr-topmenu-login")).Click();

            //Add validation to check if next element is displayed
            var validationElement = driver.FindElement(By.Name("email"));

            Assert.IsTrue(validationElement.Displayed, "Validation Failed");

            //Add wait to give time to load elements
            System.Threading.Thread.Sleep(5000);

            //Locate elements and fill in details and Login

            driver.FindElement(By.Name("email")).SendKeys("sorobe6940@mtlcz.com");
            driver.FindElement(By.Name("password")).SendKeys("Candidate!22");
            driver.FindElement(By.XPath("//*[@id=\"user-login-form-2021\"]/div[2]/form/input")).Click();
            System.Threading.Thread.Sleep(5000);

            //Validate that you are in
            var sucessMessage = driver.FindElement(By.LinkText("Hi, Test"));
            Assert.IsTrue(sucessMessage.Displayed, "Success message is displayed");

        }

        //[TearDown]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}
    }
}
