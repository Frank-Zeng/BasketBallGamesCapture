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
    public class CaptureBasktetBallController : ApiController
    {
        private CaptureDataRespository captureDataRepository;

        public CaptureBasktetBallController()
        {
            if(captureDataRepository == null)
            {
                captureDataRepository = new CaptureDataRespository();
            }
        }

        [HttpGet]
        public IHttpActionResult GetNBAGamesUrls()
        {
            return Ok(captureDataRepository.GetNBAQueryUrl());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetGamesData([FromUri] string id)
        {
            string replacement = Regex.Replace(id.Trim(), @"\\|\[|\]", "");
            string str = replacement.Replace(@"\", "").Replace("\"", "");
            List<string> urls = str.Split(',').ToList();
            var data = await captureDataRepository.GetNBASpecifyData(urls);
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetNBAGamesTodayData()
        {
            return Ok(captureDataRepository.GetNBATodayData().AsQueryable());
        }

        /*
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
        */
    }
}
