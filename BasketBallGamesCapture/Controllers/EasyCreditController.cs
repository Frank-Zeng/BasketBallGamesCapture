using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Respository;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace BasketBallGamesCapture.Controllers
{
    public class EasyCreditController : ApiController
    {
        private EasyCreditRespository easyRepository;

        public EasyCreditController()
        {
            if(easyRepository == null)
            {
                easyRepository = new EasyCreditRespository();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEasyCreditGamesTodayData()
        {
            var captureData = await easyRepository.GetEasyCreditGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }
    }
}
