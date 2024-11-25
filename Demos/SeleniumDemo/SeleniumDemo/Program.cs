using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

new DriverManager().SetUpDriver(new ChromeConfig());
var driver = new ChromeDriver();

var searchText = "salt";
var url = "https://www.coop.se/handla/sok/?q=" + searchText;

try
{
    start();

    var elements = driver.FindElements(By.XPath("//div[@class='ProductTeaser-content']")).ToList();
    if (elements is not null)
    {
        Console.WriteLine(elements.Count);
    }

    var names = driver.FindElements(By.ClassName("ProductTeaser-link")).ToList();
    if (names is not null)
    {
        Console.WriteLine(names.Count);
    }
    var weights = driver.FindElements(By.ClassName("gUGSFhfR")).ToList();
    if (weights is not null)
    {
        Console.WriteLine(weights.Count);
    }

    var prices = driver.FindElements(By.ClassName("wqjVwCAg")).ToList();
    if (prices is not null)
    {
        Console.WriteLine(prices.Count);
    }

    var comparePrices = driver.FindElements(By.XPath("//div[@class='ProductTeaser-details']/div[2]")).ToList();
    if (comparePrices is not null)
    {
        Console.WriteLine(comparePrices.Count);
    }

    var images = driver.FindElements(By.XPath("//div[@class='ProductTeaser-image']/img")).ToList();
    if (images is not null)
    {
        Console.WriteLine(images.Count);
    }

    var products = new List<Product>();
    for (int i = 0; i < elements.Count; i++) {
        var product = new Product();
        product.Id = i + 1;
        product.Name = names[i].Text;
        product.Weight = weights[i + 2].Text;
        product.Price = prices[i].Text;
        product.ComparingPrice = comparePrices[i].Text;
        product.Image = images[i].GetAttribute("src");

        products.Add(product);
    }

    foreach (var p in products)
    {
        Console.WriteLine($"{p.Id} {p.Name} {p.Weight} {p.Price}  {p.ComparingPrice}  {p.Image}");
        Console.WriteLine("=====================================================================");
    }

    //var elements = driver.FindElements(By.ClassName("ProductTeaser-info")).ToList();

    //new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));

    //if (elements is not null)
    //{
    //    Console.WriteLine(elements.Count);

    //    foreach (var element in elements) {
    //        //var name = element.FindElement(By.ClassName("ProductTeaser-link")).ToList();
    //        //if (name != null)
    //        //{
    //        //    Console.Write(name.Text);
    //        //    Console.Write("\t");
    //        //}

    //        var price = element.FindElement(By.ClassName("gUGSFhfR"));
    //        if (price != null)
    //        {
    //            Console.WriteLine(price.Text);
    //        }
    //    }
    //}

    //var elements = driver.FindElements(By.ClassName("ProductTeaser-link")).ToList();
    //foreach (var element in elements)
    //{
    //    Console.WriteLine(element.Text);
    //}

}
catch (Exception e)
{
    Console.Clear();
    Console.WriteLine(e.Message);
}
finally
{
    driver.Quit();
}

Console.WriteLine("Finished!");

void start()
{
    Console.WriteLine("Start");

    //ChromeOptions options = new ChromeOptions();
    //options.AddArgument("headless");
    //options.AddArgument("window-size=1200x600"); // Optional: Set window size
    //var driver = new ChromeDriver(options);

    driver.Navigate().GoToUrl(url);

    var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
    wait.Until(x => x.Url == url);

    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

    //close cookie approval window
    var cookieApproval = driver.FindElement(By.CssSelector("#cmpwelcomebtnyes > a"));
    if (cookieApproval is not null)
    {
        cookieApproval.Click();
    }

    ////search
    //driver.FindElement(By.CssSelector("body > div.SearchInContentContainer.js-reactComponent > div > div > div > div > div > input")).SendKeys("salt");
    //driver.FindElement(By.CssSelector("body > div.SearchInContentContainer.js-reactComponent > div > div > div > div > div > button")).Click();

    ////var hejPopUp = driver.FindElement(By.CssSelector("body > header > div > div.u-posAbsolute.u-flex.u-flexDirectionColumn.u-flexGap12.u-paddingAsm > div > div > div.vU8hKe7u > button"));
    ////if (hejPopUp is not null)
    ////{
    ////    hejPopUp.Click();
    ////}

    Thread.Sleep(3000);
    //new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public string ComparingPrice { get; set; }
    public string Weight { get; set; }
    public string Image { get; set; }
}