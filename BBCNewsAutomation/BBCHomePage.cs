using OpenQA.Selenium;

namespace BBCNewsAutomation
{
    public  class BBCHomePage: BBCBasePage
    {
        const string HOME_URL = "https://www.bbc.com";

        const string MENU_POINTS_XPATH = "//li[contains(@class, 'orb-nav')]";

        public BBCHomePage(IWebDriver driver): base(driver, "https://www.bbc.com")
        {
            
        }

        public bool CheckPageLink(string menuPointName)
        {
            ClickMenuPoint(menuPointName);
            return IsTitleContains(menuPointName);
        }


    }
}
