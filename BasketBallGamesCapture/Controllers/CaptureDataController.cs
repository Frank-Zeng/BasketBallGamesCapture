using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BasketBallGamesCapture.Controllers
{
    public class CaptureDataController : ApiController
    {
        private CaptureDataRespository captureDataRepository;

        public CaptureDataController()
        {
            captureDataRepository = new CaptureDataRespository();
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetNBAGamesTodayData()
        {
            var captureData = await captureDataRepository.GetNBATodayData();
            return Ok(captureData.AsQueryable());
        }

        [HttpGet]
        public IHttpActionResult GetEuropenGamesTodayData()
        {
            return Ok("Europen Games");
        }

        [HttpGet]
        public IHttpActionResult GetVtbLeagueGamesTodayData()
        {
            return Ok("Vtb league Games");
        }

        [HttpGet]
        public IHttpActionResult GetACBGamesTodayData()
        {
            return Ok("ACB Games");
        }

        [HttpGet]
        public IHttpActionResult GetBekoGamesTodayData()
        {
            return Ok("Beko Games");
        }
    }
}
