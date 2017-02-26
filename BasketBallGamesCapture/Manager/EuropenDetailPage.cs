using BasketBallGamesCapture.Models;
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

        public CaptureData GetDetailPageInfo(string startTime, string homeName, string visitName)
        {
            try
            {
                webDriver.Navigate().Refresh();
                var data = new CaptureData();
                var tables = webDriver.FindElements(By.Id("tblPlayerPhaseStatistics"));
                var VisitTable = tables[0];
                var ele = VisitTable.FindElement(By.XPath(".//tr[contains(@class, 'TotalFooter')]"));
                var array = ele.FindElements(By.XPath(".//td"));
                data.VisitScore = array[3].Text;
                data.VisitTwoP = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[4].Text) * 100, 1).ToString());
                data.VisitThreeP = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[5].Text) * 100, 1).ToString());
                data.VisitFT = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(array[6].Text) * 100, 1).ToString());
                data.VisitOffReb = array[7].Text;
                data.VisitDefReb = array[8].Text;
                data.VisitReb = array[9].Text;
                data.VisitASS = array[10].Text;
                data.VisitSteal = array[11].Text;
                data.VisitTO = array[12].Text;

                var HomeTable = tables[1];
                var homeEle = HomeTable.FindElement(By.XPath(".//tr[contains(@class, 'TotalFooter')]"));
                var homeArray = homeEle.FindElements(By.XPath(".//td"));
                data.HomeScore = homeArray[3].Text;
                data.HomeTwoP = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(homeArray[4].Text) * 100, 1).ToString());
                data.HomeThreeP = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(homeArray[5].Text) * 100, 1).ToString());
                data.HomeFT = string.Format("{0}%", Math.Round(WebDriverExtensions.FractionToDouble(homeArray[6].Text) * 100, 1).ToString());
                data.HomeOffReb = homeArray[7].Text;
                data.HomeDefReb = homeArray[8].Text;
                data.HomeReb = homeArray[9].Text;
                data.HomeASS = homeArray[10].Text;
                data.HomeSteal = homeArray[11].Text;
                data.HomeTO = homeArray[12].Text;

                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
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
