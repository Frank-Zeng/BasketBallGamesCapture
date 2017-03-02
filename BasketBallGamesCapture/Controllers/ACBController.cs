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
    public class ACBController : ApiController
    {
        private ACBRespository acbRepository;

        public ACBController()
        {
            if(acbRepository == null)
            {
                acbRepository = new ACBRespository();
            }
        }
   
        [HttpGet]
        public async Task<IHttpActionResult> GetACBGamesTodayData()
        {
            var captureData = await acbRepository.GetACBTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }
    }
}
