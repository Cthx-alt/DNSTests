using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ChooseByInput
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions().BinaryLocation = @"D:\CD";
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.dns-shop.ru/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var cityChoose = driver.FindElement(By.XPath("//a[@class='w-choose-city-widget pseudo-link pull-right']"));
            cityChoose.Click();
            Thread.Sleep(1000);
            var inputCity = driver.FindElement(By.XPath("//input [@data-role='search-city']"));
            inputCity.SendKeys("Москва");
            var enterCity = driver.FindElement(By.XPath("//p[@class='city-choice-suggest']"));
            enterCity.Click();

            Thread.Sleep(1000);
            var directToShop = driver.FindElement(By.XPath("//a[@class='header-top-menu__common-link']"));
            directToShop.Click();

            var actualCity = driver.FindElement(By.XPath("//h1[@class='city-shops-page__title']")).Text;
            var expectedCity = "Магазины в г. Москва";
            Assert.AreEqual(expectedCity, actualCity);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}