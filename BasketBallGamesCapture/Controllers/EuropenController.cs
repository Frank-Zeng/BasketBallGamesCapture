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
    public class EuropenController : ApiController
    {
        private EuropenRespository europenRepository;

        public EuropenController()
        {
            if(europenRepository == null)
            {
                europenRepository = new EuropenRespository();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEuropenGamesTodayData()
        {
            var captureData = await europenRepository.GetEuropenGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }       
    }
}
