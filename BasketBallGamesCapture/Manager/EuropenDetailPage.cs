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
    public class EuropenDetailPage : BasePage
    {
        public EuropenDetailPage(BrowserType targetType, string siteUrl)
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

        public void GetDetailPageInfo(string startTime, string homeName, string visitName)
        {
            var tables = webDriver.FindElements(By.Id("tblPlayerPhaseStatistics"));
            var HomeTable = tables[0];
            var VisitTable = tables[1];
            GetTableInfo(HomeTable);
        }

        public void GetTableInfo(IWebElement element)
        {
            var ele = element.FindElement(By.XPath(".//tr[contains(@class, 'TotalFooter')]"));

            var array = ele.FindElements(By.XPath(".//td"));
            var gameCostTime = array[2].Text;
            var score = array[3].Text;
            var twoPercentage = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[4].Text)*100, 1 ).ToString());
            var threePercentage = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[5].Text)*100, 1).ToString());
            var freePercentage = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[6].Text)*100, 1).ToString());
            var OffRebounds = array[7].Text;
            var DefRebounds = array[8].Text;
            var reb = array[9].Text;
            var ass = array[10].Text;
            var steal = array[11].Text;

            //Need to verify
            var block = array[13].Text;
        }

        
    }
}
