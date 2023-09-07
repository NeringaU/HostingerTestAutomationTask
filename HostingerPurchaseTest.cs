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
            driver.Manage().Window.Maximize();

            //Add wait to give time to load elements
            System.Threading.Thread.Sleep(5000);

            //Accept Privacy Policies
            driver.FindElement(By.CssSelector("[data-click-id='hgr-cookie_consent-accept_all_btn']")).Click();

            //Find and Click on the elements to choose 24months Web Hosting plan
            try
            {
                System.Threading.Thread.Sleep(5000);

                driver.FindElement(By.CssSelector("[data-click-id='hgr-header-cta-get_started']")).Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine("Element Click Intercepted: " + ex.Message);
            }

            try
            {
                System.Threading.Thread.Sleep(5000);

                driver.FindElement(By.CssSelector("[data-click-id='hgr-homepage-pricing_table-add_to_cart-hosting_hostinger_business']")).Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine("Element Click Intercepted: " + ex.Message);
            }


            driver.FindElement(By.XPath("//*[@id=\"hcart-cart-period-selector\"]/div[2]/span")).Click();


            //Add validation to check if the plan is sucesfully added to cart.
            var validationElement = driver.FindElement(By.LinkText("71.76"));

            Assert.IsTrue(validationElement.Displayed, "Plan added to purchase");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
