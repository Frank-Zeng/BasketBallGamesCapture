using BasketBallGamesCapture.Manager;
using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BasketBallGamesCapture.Respository
{
    public class CaptureDataRespository : ICaptureDataRespository
    {
        private HistoryAlertDBContext dbContext;
        private NBAWebSitePage nbaWebSitePage;

        public CaptureDataRespository()
        {
            dbContext = new HistoryAlertDBContext(ConfigureHelper.HistoryConnectString);
            nbaWebSitePage = new NBAWebSitePage(BrowserType.PhantomJSDriver);
        }

        public async Task<List<CaptureData>> GetNBATodayData()
        {
            return await nbaWebSitePage.GetNBAGamesList();
        }

    }
}