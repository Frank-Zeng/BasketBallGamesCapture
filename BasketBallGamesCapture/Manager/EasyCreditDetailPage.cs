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
    public class EasyCreditDetailPage : BasePage
    {
        public EasyCreditDetailPage(BrowserType targetType, string siteUrl)
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
            var tables = webDriver.FindElements(By.XPath(".//table/tfoot/tr"));

            var HomeArray = tables[1].Text.Split(' ');
            var homescore = HomeArray[1];
            var hometwoPercentage = HomeArray[4];
            var homethreePercentage = HomeArray[7];
            var homefgPercentage = HomeArray[10];
            var homefreePercentage = HomeArray[13];
            var homeDefRebounds = HomeArray[14];
            var homeOffRebounds = HomeArray[15];
            var homereb = HomeArray[16];
            var homeass = HomeArray[17];
            var homesteal = HomeArray[18];
            var HomeTo = HomeArray[19];

            var VisitArray = tables[3].Text.Split(' '); ;
            var visitscore = VisitArray[1];
            var visittwoPercentage = VisitArray[4];
            var visitthreePercentage = VisitArray[7];
            var visitfgPercentage = VisitArray[10];
            var visitfreePercentage = VisitArray[13];
            var visitDefRebounds = VisitArray[14];
            var visitOffRebounds = VisitArray[15];
            var visitreb = VisitArray[16];
            var visitass = VisitArray[17];
            var visitsteal = VisitArray[18];
            var visitto = VisitArray[19];
        }
    }
}
