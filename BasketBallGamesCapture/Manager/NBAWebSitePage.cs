namespace BasketBallGamesCapture.Manager
{
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;
    using Utils;
    using System.Linq;

    public class NBAWebSitePage : BasePage
    {
        public NBAWebSitePage(BrowserType targetBrowerType)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetBrowerType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(Constants.NBASiteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public async Task<List<CaptureData>> GetNBAGamesList()
        {
            //Get today games list.
            try
            {
                List<CaptureData> todayList = new List<CaptureData>();
                var elementTodaytDay = webDriver.FindElement(By.Id("day-today"));
                //    var elementNextDay = webDriver.FindElement(By.Id("day-next"));
                //  var elementPreviousDay = webDriver.FindElement(By.Id("day-previous"));

                var items = elementTodaytDay.FindElements(By.XPath(".//div[contains(@class, 'ng-scope')]"));

                var tasks = items.Select(async item => {
                    var startTime = item.FindElements(By.XPath(".//span[contains(@class, 'ng-binding')]"))[1].Text;

                    var id = item.GetAttribute("bo-gameid");
                    var names = item.FindElements(By.XPath(".//span[contains(@class, 'name')]"));
                    var HomeTeamName = names[0].Text;
                    var VisitTeamName = names[1].Text;
                    if (string.IsNullOrEmpty(HomeTeamName))
                    {
                        HomeTeamName = names[0].GetAttribute("innerHTML");
                    }
                    if (string.IsNullOrEmpty(VisitTeamName))
                    {
                        VisitTeamName = names[1].GetAttribute("innerHTML");
                    }
                    //Load detail information.
                    var data = await NavgateToNBADetailPageAsync(id.ToString(), startTime, HomeTeamName, VisitTeamName);
                    data.HomeTeamName = HomeTeamName;
                    data.VisitTeamName = VisitTeamName;
                    data.GamesStartTime = startTime;
                    todayList.Add(data);
                }).ToList();
                await Task.WhenAll(tasks);

                return todayList;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<CaptureData> NavgateToNBADetailPageAsync(string id, string startTime, string homeName, string visitName)
        {
            string url = string.Format("{0}{1}", Constants.NBADetailUrl, id);
            NBADetailPageInfo detail = new NBADetailPageInfo(BrowserType.PhantomJSDriver, url);
            return detail.GetDetailPageInfo(startTime, homeName, visitName);
        }
    }
}
