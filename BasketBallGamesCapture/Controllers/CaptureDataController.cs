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
            var captureData = await captureDataRepository.GetNBATodayDataAsync();
            return Ok(captureData.AsQueryable());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetACBGamesTodayData()
        {
            var captureData = await captureDataRepository.GetACBTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEasyCreditGamesTodayData()
        {
            var captureData = await captureDataRepository.GetEasyCreditGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEuropenGamesTodayData()
        {
            var captureData = await captureDataRepository.GetEuropenGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetVtbLeagueGamesTodayData()
        {
            var captureData = await captureDataRepository.GetVtbGamesTodayDataAsync();
            return Ok(captureData.AsQueryable());
        }
    }
}
