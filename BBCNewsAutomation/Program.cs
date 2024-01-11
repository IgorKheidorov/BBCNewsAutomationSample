using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BBCNewsAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            
            var menuPointNames = new List<string>{ "Travel", "Reel", "News", "Sport"};

            List<string> results = new List<string>();


            // POM - page object model
            BBCHomePage homePage = new BBCHomePage(driver);

            foreach (var item in menuPointNames)
            { 
               results.Add($"Result for {item} is: {homePage.CheckPageLink(item).ToString()}");

            }
            

            
            driver.Dispose();

        }
    }
}