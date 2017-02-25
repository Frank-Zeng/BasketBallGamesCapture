using BasketBallGamesCapture.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBallGamesCapture.Manager
{
    public class VtbWebSiteDetailsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "mbt-v2-game-boxscore-table")]
        private IWebElement ScoreTable { get; set; }


        public VtbWebSiteDetailsPage(BrowserType targetType, string siteUrl)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(siteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public void GetDetailPageInfo(string startTime)
        {
            var element = webDriver.FindElement(By.Id("15-400-tab-1"));
            base.ClickOnAndWaitForElementShow(element, ScoreTable);
            base.WaitForPageReady();
            base.WaitForAjax();
            var table = webDriver.FindElement(By.Id("mbt-v2-game-boxscore-table"));
            var td1 = table.FindElement(By.XPath(".//tbody/tr[14]"));
            var td2 = table.FindElement(By.XPath(".//tbody/tr[30]"));
            var src1 = td1.FindElements(By.XPath("./td"));
            var src2 = td2.FindElements(By.XPath("./td"));
            foreach (var td in src1)
            {
                var text = td.Text;
            }
            foreach (var td in src2)
            {
                var text = td.Text;
            }
        }
    }
}
