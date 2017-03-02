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
    public class EuropenRespository : BaseRespository
    {
        private EuropenWebSite europenSitePage;


        public EuropenRespository()
        {
            europenSitePage = new EuropenWebSite(BrowserType.PhantomJSDriver);
  
        }

        public async Task<List<CaptureData>> GetEuropenGamesTodayDataAsync()
        {
            return await europenSitePage.GetEuropenGamesAsync();
        }
    }
}