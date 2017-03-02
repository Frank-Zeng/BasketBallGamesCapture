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
    public class EasyCreditRespository
    {
        private EasyCreditWebSite easyCreditSitePage;
        public EasyCreditRespository()
        {
            easyCreditSitePage = new EasyCreditWebSite(BrowserType.PhantomJSDriver);
        }

        public async Task<List<CaptureData>> GetEasyCreditGamesTodayDataAsync()
        {
            return await easyCreditSitePage.GetEasyCreditTodayGamesAsync();
        }
    }
}