using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBallGamesCapture.Manager
{
    public class ACBWebSitePage : BasePage
    {
        public ACBWebSitePage(BrowserType targetBrowerType)
        {
            webDriver = WebDriverHelper.CreateWebDriverByTargetBrowser(targetBrowerType);

            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            try
            {
                webDriver.AdjustWindowSizeAndLocation()
                      .ClearCookies()
                      .SetupTimeout(30, 30);
                webDriver.Navigate().GoToUrl(Constants.ACBWebSiteUrl);

                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Some exception happened at InitializeEnvironment: { ex.Message }");
            }
        }

        public async Task<List<CaptureData>> GetTodayACBWebSitePageAsync()
        {
            try
            {
                webDriver.Navigate().Refresh();
                List<CaptureData> todayList = new List<CaptureData>();
                var items = webDriver.FindElements(By.XPath(".//div[contains(@class, 'partido borde_azul')]"));

                var tasks = items.Select( async item => {
                    try
                    {
                        var linkUrl = item.FindElements(By.XPath(".//a"))[0];

                        var url = linkUrl.GetAttribute("href");
                        //Load detail information.
                        todayList.Add(await NavgateToACBDetailPageAsync(url));
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

        public async Task<CaptureData> NavgateToACBDetailPageAsync(string url)
        {
            var str = url.Split(new char[] { 'c', '='});
            ACBWebSiteDetailPage detail = new ACBWebSiteDetailPage(BrowserType.PhantomJSDriver, string.Format(Constants.ACBWebSiteDetailUrl,str[4]));
            return detail.GetDetailInfo();
        }
    }
}
