using BasketBallGamesCapture.Manager;
using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BasketBallGamesCapture.Respository
{
    public class NBARespository : BaseRespository
    {
        private NBAWebSitePage nbaWebSitePage;
       


        public NBARespository()
        {
            nbaWebSitePage = new NBAWebSitePage(BrowserType.PhantomJSDriver);
        }

        public List<string> GetNBATodayData()
        {
            return nbaWebSitePage.GetNBAGamesList();
        }


        public async Task<IQueryable<CaptureData>> GetNBASpecifyData(List<string> urls)
        {
            var list = new List<CaptureData>();
            var tasks = urls.Select(async id =>
           {
               string url = string.Format("http://china.nba.com/static/data/game/snapshot_{0}.json", id);
               var data = new CaptureData();
               using (var client = new HttpClient())
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
                           data.VisitASS = obj.payload.awayTeam.score.assists.ToString();

                           data.HomeScore = obj.payload.homeTeam.score.score.ToString();
                           data.VisitScore = obj.payload.awayTeam.score.score.ToString();

                           data.HomeFG = obj.payload.homeTeam.score.fgpct.ToString();
                           data.VisitFG = obj.payload.awayTeam.score.fgpct.ToString();

                           data.HomeTwoP = string.Format("{0}%",
                               ((float)(obj.payload.homeTeam.score.fgm - obj.payload.homeTeam.score.tpm)
                               / (float)(obj.payload.homeTeam.score.fga - obj.payload.homeTeam.score.tpa) * 100).ToString("0.0"));
                           data.VisitTwoP = string.Format("{0}%",
                               ((float)(obj.payload.awayTeam.score.fgm - obj.payload.awayTeam.score.tpm)
                               / (float)(obj.payload.awayTeam.score.fga - obj.payload.awayTeam.score.tpa) * 100).ToString("0.0"));

                           data.HomeThreeP = obj.payload.homeTeam.score.tppct.ToString();
                           data.VisitThreeP = obj.payload.awayTeam.score.tppct.ToString();

                           data.HomeOffReb = obj.payload.homeTeam.score.offRebs.ToString();
                           data.VisitOffReb = obj.payload.awayTeam.score.offRebs.ToString();

                           data.HomeTO = obj.payload.homeTeam.score.turnovers.ToString();
                           data.VisitTO = obj.payload.awayTeam.score.turnovers.ToString();

                           data.GamesStartTime = obj.payload.boxscore.statusDesc;
                           data.GamesCurrentTime = obj.payload.boxscore.periodClock;

                           list.Add(data);
                       }
                       catch (Exception ex)
                       {
                           throw ex;
                       }
                   }
               }
           }).ToList();

            await Task.WhenAll(tasks);
            return list.AsQueryable();
        }

        public IQueryable<string> GetNBAQueryUrl()
        {
            return nbaWebSitePage.GetNBAGamesUrls().AsQueryable();
        }
    }
}