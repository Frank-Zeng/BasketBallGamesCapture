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
    public class CaptureDataRespository
    {
     //   private HistoryAlertDBContext dbContext;
        private NBAWebSitePage nbaWebSitePage;
        //private ACBWebSitePage acbWebSitePage;
        //private EasyCreditWebSite easyCreditSitePage;
        //private EuropenWebSite europenSitePage;
        //private VtbWebSitePage vtbSitePage;


        public CaptureDataRespository()
        {
        //    dbContext = new HistoryAlertDBContext(ConfigureHelper.HistoryConnectString);
            nbaWebSitePage = new NBAWebSitePage(BrowserType.PhantomJSDriver);
            //acbWebSitePage = new ACBWebSitePage(BrowserType.PhantomJSDriver);
            //easyCreditSitePage = new EasyCreditWebSite(BrowserType.PhantomJSDriver);
            //europenSitePage = new EuropenWebSite(BrowserType.PhantomJSDriver);
            //vtbSitePage = new VtbWebSitePage(BrowserType.PhantomJSDriver);
        }

        public async Task<List<CaptureData>> GetNBATodayDataAsync()
        {
            return await nbaWebSitePage.GetNBAGamesListAsync();
        }

        
        public CaptureData GetNBASpecifyData(string url)
        {
            return nbaWebSitePage.GetNBASpecifyData(url);
        }

        public IQueryable<string> GetNBAQueryUrl()
        {
            return nbaWebSitePage.GetNBAGamesUrls().AsQueryable();
        }
        

        //public async Task<List<CaptureData>> GetACBTodayDataAsync()
        //{
        //    return await acbWebSitePage.GetTodayACBWebSitePageAsync();
        //}

        //public async Task<List<CaptureData>> GetEasyCreditGamesTodayDataAsync()
        //{
        //    return await easyCreditSitePage.GetEasyCreditTodayGamesAsync();
        //}

        //public async Task<List<CaptureData>> GetEuropenGamesTodayDataAsync()
        //{
        //    return await europenSitePage.GetEuropenGamesAsync();
        //}

        //public async Task<List<CaptureData>> GetVtbGamesTodayDataAsync()
        //{
        //    return await vtbSitePage.GetVtbGamesAsync();
        //}

    }
}