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

        public CaptureData GetDetailPageInfo(string startTime, string homeName, string visitName)
        {
            try
            {
                webDriver.Navigate().Refresh();
                var data = new CaptureData();
                var tables = webDriver.FindElements(By.XPath(".//table/tfoot/tr"));

                var HomeArray = tables[3].Text.Split(' ');
                data.HomeScore = HomeArray[1];
                data.HomeTwoP = HomeArray[4];
                data.HomeThreeP = HomeArray[7];
                data.HomeFG = HomeArray[10];
                data.HomeFT = HomeArray[13];
                data.HomeDefReb = HomeArray[14];
                data.HomeOffReb = HomeArray[15];
                data.HomeReb = HomeArray[16];
                data.HomeASS = HomeArray[17];
                data.HomeSteal = HomeArray[18];
                data.HomeTO = HomeArray[19];

                var VisitArray = tables[1].Text.Split(' '); ;
                data.VisitScore = VisitArray[1];
                data.VisitTwoP = VisitArray[4];
                data.VisitThreeP = VisitArray[7];
                data.VisitFG = VisitArray[10];
                data.VisitFT = VisitArray[13];
                data.VisitDefReb = VisitArray[14];
                data.VisitOffReb = VisitArray[15];
                data.VisitReb = VisitArray[16];
                data.VisitASS = VisitArray[17];
                data.VisitSteal = VisitArray[18];
                data.VisitTO = VisitArray[19];

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
    }
}
