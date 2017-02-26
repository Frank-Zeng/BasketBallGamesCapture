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
    public class ACBWebSiteDetailPage : BasePage
    {
        public ACBWebSiteDetailPage(BrowserType targetType, string siteUrl)
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

        public CaptureData GetDetailInfo()
        {
            try
            {
                webDriver.Navigate().Refresh();
                CaptureData data = new CaptureData();

                data.HomeTeamName = webDriver.FindElement(By.XPath(".//div[contains(@class, 'statHeader team-0')]")).Text;
                data.VisitTeamName = webDriver.FindElement(By.XPath(".//div[contains(@class, 'statHeader team-1')]")).Text;

                data.HomeScore = webDriver.FindElement(By.Id("aj_1_score")).Text;
                data.VisitScore = webDriver.FindElement(By.Id("aj_2_score")).Text;

                data.VisitFG = string.Format("{0}/{1}",
                    webDriver.FindElement(By.Id("aj_1_tot_sFieldGoalsMade")).Text,
                    webDriver.FindElement(By.Id("aj_1_tot_sFieldGoalsAttempted")).Text);

                data.HomeFG = string.Format("{0}/{1}",
                    webDriver.FindElement(By.Id("aj_2_tot_sFieldGoalsMade")).Text,
                    webDriver.FindElement(By.Id("aj_2_tot_sFieldGoalsAttempted")).Text);

                data.VisitTwoP = string.Format("{0}/{1}",
                    webDriver.FindElement(By.Id("aj_1_tot_sTwoPointersMade")).Text,
                    webDriver.FindElement(By.Id("aj_1_tot_sTwoPointersAttempted")).Text);

                data.HomeTwoP = string.Format("{0}/{1}",
                          webDriver.FindElement(By.Id("aj_2_tot_sTwoPointersMade")).Text,
                         webDriver.FindElement(By.Id("aj_2_tot_sTwoPointersAttempted")).Text);

                data.VisitThreeP = string.Format("{0}/{1}",
                       webDriver.FindElement(By.Id("aj_1_tot_sThreePointersMade")).Text,
                       webDriver.FindElement(By.Id("aj_1_tot_sThreePointersAttempted")).Text);

                data.HomeThreeP = string.Format("{0}/{1}",
                         webDriver.FindElement(By.Id("aj_2_tot_sThreePointersMade")).Text,
                         webDriver.FindElement(By.Id("aj_2_tot_sThreePointersAttempted")).Text);

                data.VisitFT = string.Format("{0}/{1}",
                     webDriver.FindElement(By.Id("aj_1_tot_sFreeThrowsMade")).Text,
                     webDriver.FindElement(By.Id("aj_1_tot_sFreeThrowsAttempted")).Text);

                data.HomeFT = string.Format("{0}/{1}",
                         webDriver.FindElement(By.Id("aj_2_tot_sFreeThrowsMade")).Text,
                         webDriver.FindElement(By.Id("aj_2_tot_sFreeThrowsAttempted")).Text);

                data.VisitReb = webDriver.FindElement(By.Id("aj_1_tot_sReboundsTotal")).Text;

                data.HomeReb = webDriver.FindElement(By.Id("aj_2_tot_sReboundsTotal")).Text;

                data.VisitASS = webDriver.FindElement(By.Id("aj_1_tot_sAssists")).Text;

                data.HomeASS = webDriver.FindElement(By.Id("aj_2_tot_sAssists")).Text;

                return data;
            }
            catch (Exception ex)
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
