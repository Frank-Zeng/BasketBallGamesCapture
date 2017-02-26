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
    public class NBADetailPageInfo : BasePage
    {
        public NBADetailPageInfo(BrowserType targetType, string siteUrl) :base()
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

        public CaptureData GetDetailPageInfo( string homeName, string visitName)
        {
            try
            {
                webDriver.Navigate().Refresh();

                CaptureData data = new CaptureData();
                var tables = webDriver.FindElements(By.XPath(".//table[contains(@class, 'sib-zebra-stripes no-sort ng-scope')]"));
                var homeTable = tables[0];
                var visitTable = tables[1];

                var home = GetTableInfo(homeTable);
                data.HomeScore = home[3];
                data.HomeReb = home[4];
                data.HomeASS = home[5];
                data.HomeSteal = home[6];
                data.HomeBlock = home[7];
                data.HomeFG = home[10];
                data.HomeThreeP = home[13];
                data.HomeFT = home[16];
                data.HomeOffReb = home[17];
                data.HomeDefReb = home[18];
                data.HomeTwoP = string.Format("{0}%", ((float.Parse(home[8]) - float.Parse(home[11])) / (float.Parse(home[9]) - float.Parse(home[12])) * 100).ToString("0.0"));
                data.HomeTO = home[19];
                // data.HomeTwoP = ((float.Parse(home[8]) - float.Parse(home[11])) / (float.Parse(home[9]) - float.Parse(home[12]))).ToString();

                var visit = GetTableInfo(visitTable);
                data.VisitScore = visit[3];
                data.VisitReb = visit[4];
                data.VisitASS = visit[5];
                data.VisitSteal = visit[6];
                data.VisitBlock = visit[7];
                data.VisitFG = visit[10];
                data.VisitThreeP = visit[13];
                data.VisitFT = visit[16];
                data.VisitOffReb = visit[17];
                data.VisitDefReb = visit[18];
                data.VisitTwoP = string.Format("{0}%", ((float.Parse(visit[8]) - float.Parse(visit[11])) / (float.Parse(visit[9]) - float.Parse(visit[12])) * 100).ToString("0.0"));
                data.VisitTO = visit[19];
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

        public string[] GetTableInfo(IWebElement element)
        {
            var ele = element.FindElement(By.XPath(".//tr[contains(@class, 'caption')]"));
            var total = ele.FindElement(By.XPath("following-sibling::*")).Text;
            var array = total.Split(' ');
            return array;
        }
    }
}
