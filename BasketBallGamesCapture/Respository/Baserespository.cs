using BasketBallGamesCapture.Models;
using BasketBallGamesCapture.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketBallGamesCapture.Respository
{
    public class BaseRespository
    {
         protected HistoryAlertDBContext dbContext;

        public BaseRespository()
        {
        //    dbContext = new HistoryAlertDBContext(ConfigureHelper.HistoryConnectString);
        }
    }
}