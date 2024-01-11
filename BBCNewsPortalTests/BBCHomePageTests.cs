using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BBCNewsAutomation;


namespace BBCNewsPortalTests
{
    [TestClass]
    public class BBCHomePageTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        [DataRow("Reel")]
        [DataRow("Travel")]
        [DataRow("Worklife")]        
        [DataRow("Sport")]
        

        public void CorrectMenuPointLinksTest(string menuItem)
        {            
            BBCHomePage homePage = new BBCHomePage(_driver);
            Assert.IsTrue(homePage.CheckPageLink(menuItem));
        }


        [TestMethod]
        public void CheckSearchPagePositive()
        {
            BBCSearchPage page = new BBCSearchPage(_driver);
            var results= page.GetSearchResults("Mexico");

            var filteredResults = results.Where(x => x.Contains("Mexico")).ToList();

            Assert.IsTrue(filteredResults.Count >= results.Count / 2);
        }

        [TestMethod]
        public void CheckSearchPageNegative()
        {
            BBCSearchPage page = new BBCSearchPage(_driver);
            var results = page.GetSearchResults("sdkafjdsafasfasdf");           

            Assert.IsTrue(results.Where(x => x.Contains("Sorry")).Count() > 0);
        }




        [TestCleanup]
        public void CleanUp()
        {
            _driver.Dispose();
        }

    }
}