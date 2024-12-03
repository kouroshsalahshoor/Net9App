using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumxUnitTest
{
    public class UnitTest1
    {
        IWebDriver driver;

        [Fact]
        public void Test1()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl(new Uri("https://localhost:7176/categories"));
        }
    }
}
