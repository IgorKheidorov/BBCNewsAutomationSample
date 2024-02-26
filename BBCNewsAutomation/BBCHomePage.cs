using OpenQA.Selenium;

namespace BBCNewsAutomation
{
    public  class BBCHomePage: BBCBasePage
    {
        const string HOME_URL = "https://www.bbc.com";

        const string MENU_POINTS_XPATH = "//li[contains(@class, 'orb-nav')]";

        public BBCHomePage(IWebDriver driver): base(driver, "https://www.bbc.com")
        {
            Thread.Sleep(1000);

            var frame = driver.FindElement(By.XPath("//iframe[@title ='SP Consent Message']"));

            driver.SwitchTo().Frame(frame);
            var element = driver.FindElement(By.XPath("//button[@title='I agree']"));
            element.Click();

            driver.SwitchTo().ParentFrame();

        }

        public bool CheckPageLink(string menuPointName)
        {
            ClickMenuPoint(menuPointName);
            return IsTitleContains(menuPointName);
        }

        public bool CheckDate()
        {
            return true;
        }


    }
}
