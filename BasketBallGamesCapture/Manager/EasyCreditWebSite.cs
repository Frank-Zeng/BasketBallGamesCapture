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
    public class EasyCreditWebSite : BasePage
    {
        public EasyCreditWebSite(BrowserType targetBrowerType)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetBrowerType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(Constants.EasyCreditSiteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public async Task<List<CaptureData>> GetEasyCreditTodayGamesAsync()
        {
            try
            {
                webDriver.Navigate().Refresh();
                List<CaptureData> todayList = new List<CaptureData>();
                var gamesListPanel = webDriver.FindElement(By.Id("gamecenter-content"));

                //Get the games who has not finished.
           //     var upComingPanel = gamesListPanel.FindElements(By.XPath(".//div[contains(@class, 'upcoming')]"));

                //Get the games who has finished.
                var finishPanel = gamesListPanel.FindElements(By.XPath(".//div[contains(@class, 'finished')]"));

                var tasks = finishPanel.Select(async item =>
                {
                    try
                    {
                        var timeElement = item.FindElement(By.XPath(".//div[contains(@class, 'info')]/time"));
                        var timeString = timeElement.Text;
                        if (string.IsNullOrEmpty(timeString))
                        {
                            timeString = timeElement.GetAttribute("innerHTML");
                        }
                        var date = timeString.Split(',')[0];
                        var time = timeString.Split(',')[1];
                        var easyDate = date.Split('.');
                        var day = easyDate[0];
                        var month = easyDate[1];
                        var year = string.Format("20{0}", easyDate[2]);

                        if (string.Equals(Int32.Parse(year), DateTime.UtcNow.Year)
                            && string.Equals(Int32.Parse(month), DateTime.UtcNow.Month)
                            && string.Equals(Int32.Parse(day), DateTime.UtcNow.Day))
                        {
                            var nameList = item.FindElements(By.XPath(".//table/tbody/tr/td/img"));
                            var nameList2 = item.FindElements(By.XPath(".//table/tbody/tr/td"));

                            var homeNameElement = nameList2[0];
                            var visitNameElement = nameList2[2];
                            var homeName = homeNameElement.Text;
                            var visitName = visitNameElement.Text;
                            if (string.IsNullOrEmpty(homeName))
                            {
                                homeName = homeNameElement.GetAttribute("innerHTML");
                            }
                            if (string.IsNullOrEmpty(visitName))
                            {
                                visitName = visitNameElement.GetAttribute("innerHTML");
                            }
                            homeName = homeName.Split('>')[1];
                            visitName = visitName.Split('>')[1];

                            var ele = item.FindElement(By.XPath("./div[contains(@class, 'more')]/a[2]"));
                            var linkUrl = ele.GetAttribute("href");
                            var data = await NavigateToDetailPageInfoAsync(linkUrl, time, homeName, visitName);
                            todayList.Add(data);
                        }
                    }
                    catch
                    {
                        return;
                    }

                }).ToList();

                await Task.WhenAll(tasks);

                return todayList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
        }

        public async Task<CaptureData> NavigateToDetailPageInfoAsync(string url, string time, string homeName, string visitName)
        {
            EasyCreditDetailPage driver = new EasyCreditDetailPage(BrowserType.PhantomJSDriver, url);
            return driver.GetDetailPageInfo(time, homeName, visitName);
        }
    }
}
