using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCNewsAutomation
{
    public class BBCSearchPage
    {
        IWebDriver _webDriver;

        const string SEARCH_BOX_XPATH = "//input[@value]";
        const string SEARCH_BUTTON_XPATH = "//*[@id='searchButton']";
        const string SEARCH_RESULT_TEXT_XPATH = "//p";

        const string PAGE_URL = @"https://www.bbc.com/search";


        WebDriverWait _wait;

        public BBCSearchPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Url = PAGE_URL;
            _webDriver.Manage().Window.Maximize();
        }


        public List<string> GetSearchResults(string infoToSearch)
        {
            var searchBox = _webDriver.FindElement(By.XPath(SEARCH_BOX_XPATH));
            searchBox.SendKeys(infoToSearch);

            var searchButton = _webDriver.FindElement(By.XPath(SEARCH_BUTTON_XPATH));
            searchButton.Click();

            Thread.Sleep(1000);

            var searchResults = _webDriver.FindElements(By.XPath(SEARCH_RESULT_TEXT_XPATH));
            return searchResults.Select(x => x.Text).ToList();
        }

    }
}
