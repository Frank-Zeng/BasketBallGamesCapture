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
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Net;

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

        
        public List<string> GetNBAGamesUrls()
        {
            try
            {
                List<string> urls = new List<string>();
                var elementTodaytDay = webDriver.FindElement(By.Id("day-today"));
                var items = elementTodaytDay.FindElements(By.XPath(".//div[contains(@class, 'ng-scope')]"));

                items.ForEach( item => {
                    try
                    {
                        var id = item.GetAttribute("bo-gameid");
                        if (!string.IsNullOrEmpty(id))
                        {
                            urls.Add(id);
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }

                });

                return urls;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CaptureData> GetNBASpecifyData(List<string> urls)
        {
            try
            {
                /*
                string url = string.Format("{0}{1}", Constants.NBADetailUrl, id);
                webDriver.Navigate().GoToUrl(url);
                PageFactory.InitElements(webDriver, this);
                base.WaitForPageReady();
                base.WaitForAjax();

                CaptureData data = new CaptureData();
                var timeDiv = webDriver.FindElement(By.XPath(".//div[contains(@class, 'time livestate poststate')]"));
                if (!string.IsNullOrEmpty(timeDiv.Text) && timeDiv.Text.Contains("直播"))
                {
                    var array = timeDiv.Text.Split(' ');

                    //Load detail information.
                    return GetDetailPageInfo();
                }
                */
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public CaptureData GetDetailPageInfo()
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] GetTableInfo(IWebElement element)
        {
            var ele = element.FindElement(By.XPath(".//tr[contains(@class, 'caption')]"));
            var total = ele.FindElement(By.XPath("following-sibling::*")).Text;
            var array = total.Split(' ');
            return array;
        }

        public List<string> GetNBAGamesList()
        {
            //Get today games list.
            try
            {
                webDriver.Navigate().Refresh();
                List<string> todayList = new List<string>();
                var elementTodaytDay = webDriver.FindElement(By.Id("day-today"));

                var items = elementTodaytDay.FindElements(By.XPath(".//div[contains(@class, 'ng-scope')]"));

                foreach(var item in items)
                {
                    var id = item.GetAttribute("bo-gameid");
                    if (!string.IsNullOrEmpty(id))
                    {
                        todayList.Add(id.ToString());
                    }
                }


                /*
                var tasks = items.Select(async item => {
                    try
                    {
                  //      var timeDiv = item.FindElement(By.XPath(".//div[contains(@class, 'time livestate poststate')]"));
                  //      if (!string.IsNullOrEmpty(timeDiv.Text) && timeDiv.Text.Contains("直播"))
                  //      {
                        //    var array = timeDiv.Text.Split(' ');
                            var id = item.GetAttribute("bo-gameid");
                            if(!string.IsNullOrEmpty(id))
                            {
                            
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
                                var data = await NavgateToNBADetailPageAsync(id.ToString(), HomeTeamName, VisitTeamName);
                         //       data.HomeTeamName = HomeTeamName;
                          //      data.VisitTeamName = VisitTeamName;
                           //     data.GamesStartTime = array[3];
                          //      data.GamesCurrentTime = array[1];
                          
                            //    todayList.Add(id.ToString());
                     //       }
                        }
                    }
                    catch(Exception ex)
                    {
                        return;
                    }
                   
                }).ToList();
                await Task.WhenAll(tasks);
                */
                return todayList;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<CaptureData> NavgateToNBADetailPageAsync(string id, string homeName, string visitName)
        {
            CaptureData data = new CaptureData();
            string url = string.Format("http://china.nba.com/static/data/game/snapshot_{0}.json",id);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        RootObject obj = JsonConvert.DeserializeObject<RootObject>(result);
                        data.HomeTeamName = obj.payload.homeTeam.profile.displayAbbr;
                        data.VisitTeamName = obj.payload.awayTeam.profile.displayAbbr;
                        data.HomeFT = obj.payload.homeTeam.score.ftpct.ToString();
                        data.VisitFT = obj.payload.awayTeam.score.ftpct.ToString();
                        data.HomeTO = obj.payload.homeTeam.score.turnovers.ToString();
                        data.VisitTO = obj.payload.awayTeam.score.turnovers.ToString();
                        data.HomeASS = obj.payload.homeTeam.score.assists.ToString();
                        data.HomeASS = obj.payload.awayTeam.score.assists.ToString();
                        data.HomeScore = obj.payload.homeTeam.score.score.ToString();
                        data.VisitScore = obj.payload.awayTeam.score.score.ToString();
                        data.HomeFG = obj.payload.homeTeam.score.fgpct.ToString();
                        data.VisitFG = obj.payload.awayTeam.score.fgpct.ToString();
                        data.HomeTwoP = string.Format("{0}%",
                            ((float)(obj.payload.homeTeam.score.fgm - obj.payload.homeTeam.score.tpm) 
                            / (float)(obj.payload.homeTeam.score.fga - obj.payload.homeTeam.score.tpa)*100).ToString("0.0"));
                        data.VisitTwoP = string.Format("{0}%",
                            ((float)(obj.payload.awayTeam.score.fgm - obj.payload.awayTeam.score.tpm)
                            / (float)(obj.payload.awayTeam.score.fga - obj.payload.awayTeam.score.tpa)*100).ToString("0.0"));

                        data.HomeThreeP = obj.payload.homeTeam.score.tppct.ToString();
                        data.VisitThreeP = obj.payload.awayTeam.score.tppct.ToString();

                        data.HomeOffReb = obj.payload.homeTeam.score.offRebs.ToString();
                        data.VisitOffReb = obj.payload.awayTeam.score.offRebs.ToString();

                        data.HomeTO = obj.payload.homeTeam.score.turnovers.ToString();
                        data.VisitTO = obj.payload.awayTeam.score.turnovers.ToString();
                        return data;
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }
    }
}
