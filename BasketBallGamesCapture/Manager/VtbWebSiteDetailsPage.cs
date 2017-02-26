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

        public CaptureData GetDetailPageInfo(string startTime)
        {
            try
            {
                webDriver.Navigate().Refresh();

                CaptureData data = new CaptureData();

                var element = webDriver.FindElement(By.Id("15-400-tab-1"));
                base.ClickOnAndWaitForElementShow(element, ScoreTable);
                base.WaitForPageReady();
                base.WaitForAjax();
                var table = webDriver.FindElement(By.Id("mbt-v2-game-boxscore-table"));
                var visitnameEle = table.FindElements(By.XPath(".//thead/tr[1]/th"));
                data.VisitTeamName = visitnameEle[0].Text;
                var homenameEle = table.FindElements(By.XPath(".//tbody/tr[17]/td"));
                data.HomeTeamName = homenameEle[0].Text;

                var td1 = table.FindElement(By.XPath(".//tbody/tr[14]"));
                var td2 = table.FindElement(By.XPath(".//tbody/tr[30]"));
                var src1 = td1.FindElements(By.XPath("./td"));
                var src2 = td2.FindElements(By.XPath("./td"));

                data.VisitTwoP = src1[3].Text;
                data.VisitThreeP = src1[5].Text;
                data.VisitFG = src1[7].Text;
                data.VisitFT = src1[9].Text;
                data.VisitOffReb = src1[10].Text;
                data.VisitDefReb = src1[11].Text;
                data.VisitReb = src1[12].Text;
                data.VisitASS = src1[13].Text;
                data.VisitTO = src1[15].Text;
                data.VisitScore = src1[22].Text;

                data.HomeTwoP = src2[3].Text;
                data.HomeThreeP = src2[5].Text;
                data.HomeFG = src2[7].Text;
                data.HomeFT = src2[9].Text;
                data.HomeOffReb = src2[10].Text;
                data.HomeDefReb = src2[11].Text;
                data.HomeReb = src2[12].Text;
                data.HomeASS = src2[13].Text;
                data.HomeTO = src2[15].Text;
                data.HomeScore = src2[22].Text;

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
