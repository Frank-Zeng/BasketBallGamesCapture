using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketBallGamesCapture.Models
{
    public class CaptureData
    {
        //比赛当前小节剩余时间
        public string GamesStartTime { get; set; }

        //比赛当前小节
        public string GamesCurrentTime { get; set; }

        //主队名称
        public string HomeTeamName { get; set; }

        //客队名称
        public string VisitTeamName { get; set; }

        //主队投篮命中率
        public string HomeFG { get; set; }

        //客队投篮命中率
        public string VisitFG { get; set; }

        //主队得分数
        public string HomeScore { get; set; }

        //客队得分数
        public string VisitScore { get; set; }

        //主队篮板数
        public string HomeReb { get; set; }

        //客队篮板数
        public string VisitReb { get; set; }

        //主队两分球命中率
        public string HomeTwoP { get; set; }

        //客队两分球命中率
        public string VisitTwoP { get; set; }

        //主队三分球命中率
        public string HomeThreeP { get; set; }

        //客队三分球命中率
        public string VisitThreeP { get; set; }

        //主队罚球命中率
        public string HomeFT { get; set; }

        //客队罚球命中率
        public string VisitFT { get; set; }

        //主队助攻数
        public string HomeASS { get; set; }

        //客队助攻数
        public string VisitASS { get; set; }

        //主队抢断数
        public string HomeSteal { get; set; }

        //客队抢断数
        public string VisitSteal { get; set; }

        //主队进攻篮板数
        public string HomeOffReb { get; set; }

        //客队进攻篮板数
        public string VisitOffReb { get; set; }

        //主队防守篮板数
        public string HomeDefReb { get; set; }

        //客队防守篮板数
        public string VisitDefReb { get; set; }

        //主队盖帽数
        public string HomeBlock { get; set; }

        //客队盖帽数
        public string VisitBlock { get; set; }

        //主队失误数
        public string HomeTO { get; set; }

        //客队失误数
        public string VisitTO { get; set; }
    }
}