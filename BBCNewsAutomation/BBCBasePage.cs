using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace BBCNewsAutomation
{
    public abstract class BBCBasePage
    {
        IWebDriver _webDriver;
        Actions _actions;

        ILogger _logger;

        WebDriverWait _wait;
        const string MENU_POINTS_XPATH = "//li[contains(@class, 'orb-nav')]";

        //SOLID

        public BBCBasePage(IWebDriver _driver, string URL)
        {
            _webDriver = _driver;
            _webDriver.Url = URL;
            _webDriver.Manage().Window.Maximize();
            _logger = LoggerManager.GetLoggerInstance();
            
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _actions = new Actions(_webDriver);
        }

        public IReadOnlyCollection<IWebElement> GetElementsByXPath(string xPath)
        {
            _logger.LogMessage($"{ xPath} GetElementsByXPath were found");
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)))
                              .Where(x => x.Displayed && x.Enabled).ToList();
        }

        public IWebElement GetElementByXPath(string xPath)
        {
            return _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));                             
        }

        public bool IsTitleContains(string partialTitle)
        {
            return _wait.Until(ExpectedConditions.TitleContains(partialTitle));
        }

        public void ClickElement(IWebElement element)
        {
         //   _actions = new Actions(_webDriver);
            _actions.ScrollToElement(element).Perform();
            _actions.MoveToElement(element).Perform();
            _webDriver.ExecuteJavaScript("window.scrollBy(0,-800);");

            element.Click();
        
        }

        public void ClickMenuPoint(string menuPoint) 
        {
            var element = GetElementsByXPath(MENU_POINTS_XPATH).Where(x => x.Text == menuPoint).First();

            if (element == null)
            {
                _logger.LogError($"Menu point {menuPoint} was not found");
            }
            else 
            {
                _logger.LogMessage($"Menu point {menuPoint} was found");
             
                ClickElement(element);
            }
              
        }








    }
}
