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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace BasketBallGamesCapture.Manager
{
    public class VtbWebSitePage : BasePage
    {
        public VtbWebSitePage(BrowserType targetBrowerType)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetBrowerType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(Constants.VtbWebSiteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public async Task<List<CaptureData>> GetVtbGamesAsync()
        {
            try
            {
                webDriver.Navigate().Refresh();
                List<CaptureData> todayList = new List<CaptureData>();

                var gameslist = webDriver.FindElement(By.XPath(".//ul[contains(@class, 'games-list')]"));
                var gamesUrl = gameslist.FindElements(By.XPath(".//li"));

                var tasks = gamesUrl.Select(async url => {
                    var header = gamesUrl[13].FindElement(By.XPath(".//div[contains(@class, 'panel-heading')]"));
                    var title = header.Text;
                    if (string.IsNullOrEmpty(title))
                    {
                        title = Regex.Replace(header.GetAttribute("innerHTML").Trim().Replace(" ", ""), @"\t|\n|\r", "");
                    }

                    var date = title.Trim().Split('/')[0];

                    //startTime will show 19:00 MSC.
                    //  var startTime = title.Trim().Split('/')[1].Trim().Split(' ')[0];
                    // startTime will show 19:00
                    var startTime = title.Trim().Split('/')[1];

                    var list = date.Split('.');
                    if (DateTime.UtcNow.Day.Equals(Int32.Parse(list[0])) && DateTime.UtcNow.Month.Equals(Int32.Parse(list[1])))
                    {
                        var linkUrl = url.FindElement(By.XPath(".//div[contains(@class, 'panel-footer')]/a")).GetAttribute("href");
                        //For test use url: "http://www.vtb-league.com/ru/game/2793129/#stat"
                        var data = await NavigateToVtbDetailPageAsync(linkUrl, startTime);

                        todayList.Add(data);
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

        public async Task<CaptureData> NavigateToVtbDetailPageAsync(string url, string startTime)
        {
            VtbWebSiteDetailsPage detail = new VtbWebSiteDetailsPage(BrowserType.PhantomJSDriver, url);
            return detail.GetDetailPageInfo(startTime);
        }
    }
}
