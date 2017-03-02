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
    public class VtbLeagueController : ApiController
    {
        private VtbRespository vtbRepository;

        public VtbLeagueController()
        {
            if(vtbRepository == null)
            {
                vtbRepository = new VtbRespository();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetVtbLeagueGamesTodayData()
        {
            var captureData = await vtbRepository.GetVtbGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }
        
    }
}
