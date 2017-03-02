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
    public class NBAController : ApiController
    {
        private NBARespository nbaRepository;

        public NBAController()
        {
            if(nbaRepository == null)
            {
                nbaRepository = new NBARespository();
            }
        }

        [HttpGet]
        public IHttpActionResult GetNBAGamesUrls()
        {
            return Ok(nbaRepository.GetNBAQueryUrl());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetGamesData([FromUri] string id)
        {
            string replacement = Regex.Replace(id.Trim(), @"\\|\[|\]", "");
            string str = replacement.Replace(@"\", "").Replace("\"", "");
            List<string> urls = str.Split(',').ToList();
            var data = await nbaRepository.GetNBASpecifyData(urls);
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetNBAGamesTodayData()
        {
            return Ok(nbaRepository.GetNBATodayData().AsQueryable());
        }
    }
}
