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
    public class EuropenWebSite : BasePage
    {
        public EuropenWebSite(BrowserType targetBrowerType)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetBrowerType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(Constants.EuropenSiteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public async Task<List<CaptureData>> GetEuropenGamesAsync()
        {
            try
            {

                webDriver.Navigate().Refresh();
                List<CaptureData> todayList = new List<CaptureData>();

                var gameslink = webDriver.FindElements(By.XPath(".//a[contains(@class, 'game-link')]"));
                var tasks = gameslink.Select(async game => {
                    try
                    {
                        //It will get empty string if the tag is hidden style. So must use innerHTML to get the text.
                        var dateTimeElement = game.FindElement(By.XPath(".//span[contains(@class, 'date')]"));
                        var dateTime = dateTimeElement.Text;
                        if (string.IsNullOrEmpty(dateTime))
                        {
                            dateTime = dateTimeElement.GetAttribute("innerHTML");
                        }
                        var startTimeElement = game.FindElement(By.XPath(".//span[contains(@class, 'hour')]"));
                        var startTime = startTimeElement.Text;
                        if (string.IsNullOrEmpty(startTime))
                        {
                            startTime = startTimeElement.GetAttribute("innerHTML");
                        }
                        var HomeTeamElement = game.FindElements(By.XPath(".//span[contains(@class, 'name')]"))[0];
                        var VisitTeamElement = game.FindElements(By.XPath(".//span[contains(@class, 'name')]"))[1];
                        var HomeTeamName = HomeTeamElement.Text;
                        var VisitTeamName = VisitTeamElement.Text;

                        if (string.IsNullOrEmpty(HomeTeamName))
                        {
                            HomeTeamName = HomeTeamElement.GetAttribute("innerHTML");
                        }
                        if (string.IsNullOrEmpty(VisitTeamName))
                        {
                            VisitTeamName = VisitTeamElement.GetAttribute("innerHTML");
                        }
                        var linkUrl = game.GetAttribute("href");

                        var time = dateTime.Split(' ');
                        if (CompareMonth(time[0]) && string.Equals(Int32.Parse(time[1]), DateTime.UtcNow.Day))
                        {
                            var data = await NavigateToEuropenDetailPageInfoAsync(linkUrl, startTime, HomeTeamName, VisitTeamName);
                            todayList.Add(data);
                        }
                    }
                    catch(Exception ex)
                    {
                        return;
                    }
                }).ToList();

                await Task.WhenAll(tasks);

                return todayList;
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

        private bool CompareMonth(string month)
        {
            var currentTime = DateTime.UtcNow.Month;
            var str = month.Trim().ToLower();
            switch (str)
            {
                case "jan":
                    return string.Equals(currentTime, 1);
                case "feb":
                    return string.Equals(currentTime, 2);
                case "mar":
                    return string.Equals(currentTime, 3);
                case "apr":
                    return string.Equals(currentTime, 4);
                case "may":
                    return string.Equals(currentTime, 5);
                case "jun":
                    return string.Equals(currentTime, 6);
                case "jul":
                    return string.Equals(currentTime, 7);
                case "aug":
                    return string.Equals(currentTime, 8);
                case "sep":
                    return string.Equals(currentTime, 9);
                case "oct":
                    return string.Equals(currentTime, 10);
                case "nov":
                    return string.Equals(currentTime, 11);
                case "dec":
                    return string.Equals(currentTime, 12);
                default:
                    return false;
            }
        }

        public async Task<CaptureData> NavigateToEuropenDetailPageInfoAsync(string url, string startTime, string homeName, string visitName)
        {
            EuropenDetailPage detail = new EuropenDetailPage(BrowserType.PhantomJSDriver, url);
            return detail.GetDetailPageInfo(startTime, homeName, visitName);
        }
    }
}
