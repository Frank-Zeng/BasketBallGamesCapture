using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBallGamesCapture.Models
{
    public class User
    {
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string locale { get; set; }
        public string timeZone { get; set; }
        public string timeZoneCity { get; set; }
    }

    public class Device
    {
        public object clazz { get; set; }
    }

    public class Context
    {
        public User user { get; set; }
        public Device device { get; set; }
    }

    public class Error
    {
        public object detail { get; set; }
        public string isError { get; set; }
        public object message { get; set; }
    }

    public class GameProfile
    {
        public string arenaLocation { get; set; }
        public string arenaName { get; set; }
        public string awayTeamId { get; set; }
        public string gameId { get; set; }
        public string homeTeamId { get; set; }
        public string number { get; set; }
        public object scheduleCode { get; set; }
        public string seasonType { get; set; }
        public string sequence { get; set; }
        public string utcMillis { get; set; }
    }

    public class Boxscore
    {
        public string attendance { get; set; }
        public int awayScore { get; set; }
        public string gameLength { get; set; }
        public int homeScore { get; set; }
        public string officialsDisplayName1 { get; set; }
        public string officialsDisplayName2 { get; set; }
        public string officialsDisplayName3 { get; set; }
        public string period { get; set; }
        public string periodClock { get; set; }
        public string status { get; set; }
        public string statusDesc { get; set; }
        public string ties { get; set; }
    }

    public class Url
    {
        public string displayText { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Profile
    {
        public string abbr { get; set; }
        public string city { get; set; }
        public string cityEn { get; set; }
        public string code { get; set; }
        public string conference { get; set; }
        public string displayAbbr { get; set; }
        public string displayConference { get; set; }
        public string division { get; set; }
        public string id { get; set; }
        public bool isAllStarTeam { get; set; }
        public bool isLeagueTeam { get; set; }
        public string leagueId { get; set; }
        public string name { get; set; }
        public string nameEn { get; set; }
    }

    public class Standing
    {
        public object clinched { get; set; }
        public int confRank { get; set; }
        public int divRank { get; set; }
        public string last10 { get; set; }
        public int losses { get; set; }
        public string onHotStreak { get; set; }
        public string streak { get; set; }
        public int wins { get; set; }
    }

    public class Score
    {
        public int assists { get; set; }
        public int biggestLead { get; set; }
        public int blocks { get; set; }
        public int blocksAgainst { get; set; }
        public int defRebs { get; set; }
        public int disqualifications { get; set; }
        public int ejections { get; set; }
        public int fastBreakPoints { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int flagrantFouls { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int fullTimeoutsRemaining { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int ot10Score { get; set; }
        public int ot1Score { get; set; }
        public int ot2Score { get; set; }
        public int ot3Score { get; set; }
        public int ot4Score { get; set; }
        public int ot5Score { get; set; }
        public int ot6Score { get; set; }
        public int ot7Score { get; set; }
        public int ot8Score { get; set; }
        public int ot9Score { get; set; }
        public int pointsInPaint { get; set; }
        public int pointsOffTurnovers { get; set; }
        public int q1Score { get; set; }
        public int q2Score { get; set; }
        public int q3Score { get; set; }
        public int q4Score { get; set; }
        public int rebs { get; set; }
        public int score { get; set; }
        public int seconds { get; set; }
        public int shortTimeoutsRemaining { get; set; }
        public int steals { get; set; }
        public int technicalFouls { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class Matchup
    {
        public string confRank { get; set; }
        public string divRank { get; set; }
        public string losses { get; set; }
        public object seriesText { get; set; }
        public string wins { get; set; }
    }

    public class Profile2
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class Boxscore2
    {
        public string dnpReason { get; set; }
        public string isStarter { get; set; }
        public string onCourt { get; set; }
        public string plusMinus { get; set; }
        public string position { get; set; }
    }

    public class StatTotal
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class GamePlayer
    {
        public Profile2 profile { get; set; }
        public Boxscore2 boxscore { get; set; }
        public StatTotal statTotal { get; set; }
    }

    public class Profile3
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal2
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class PointGameLeader
    {
        public Profile3 profile { get; set; }
        public StatTotal2 statTotal { get; set; }
    }

    public class Profile4
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal3
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class AssistGameLeader
    {
        public Profile4 profile { get; set; }
        public StatTotal3 statTotal { get; set; }
    }

    public class Profile5
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal4
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class ReboundGameLeader
    {
        public Profile5 profile { get; set; }
        public StatTotal4 statTotal { get; set; }
    }

    public class Profile6
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatAverage
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class PointSeasonLeader
    {
        public Profile6 profile { get; set; }
        public StatAverage statAverage { get; set; }
    }

    public class Profile7
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatAverage2
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class AssistSeasonLeader
    {
        public Profile7 profile { get; set; }
        public StatAverage2 statAverage { get; set; }
    }

    public class Profile8
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatAverage3
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class ReboundSeasonLeader
    {
        public Profile8 profile { get; set; }
        public StatAverage3 statAverage { get; set; }
    }

    public class HomeTeam
    {
        public Profile profile { get; set; }
        public Standing standing { get; set; }
        public Score score { get; set; }
        public Matchup matchup { get; set; }
        public List<GamePlayer> gamePlayers { get; set; }
        public PointGameLeader pointGameLeader { get; set; }
        public AssistGameLeader assistGameLeader { get; set; }
        public ReboundGameLeader reboundGameLeader { get; set; }
        public PointSeasonLeader pointSeasonLeader { get; set; }
        public AssistSeasonLeader assistSeasonLeader { get; set; }
        public ReboundSeasonLeader reboundSeasonLeader { get; set; }
    }

    public class Profile9
    {
        public string abbr { get; set; }
        public string city { get; set; }
        public string cityEn { get; set; }
        public string code { get; set; }
        public string conference { get; set; }
        public string displayAbbr { get; set; }
        public string displayConference { get; set; }
        public string division { get; set; }
        public string id { get; set; }
        public bool isAllStarTeam { get; set; }
        public bool isLeagueTeam { get; set; }
        public string leagueId { get; set; }
        public string name { get; set; }
        public string nameEn { get; set; }
    }

    public class Standing2
    {
        public object clinched { get; set; }
        public int confRank { get; set; }
        public int divRank { get; set; }
        public string last10 { get; set; }
        public int losses { get; set; }
        public string onHotStreak { get; set; }
        public string streak { get; set; }
        public int wins { get; set; }
    }

    public class Score2
    {
        public int assists { get; set; }
        public int biggestLead { get; set; }
        public int blocks { get; set; }
        public int blocksAgainst { get; set; }
        public int defRebs { get; set; }
        public int disqualifications { get; set; }
        public int ejections { get; set; }
        public int fastBreakPoints { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int flagrantFouls { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int fullTimeoutsRemaining { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int ot10Score { get; set; }
        public int ot1Score { get; set; }
        public int ot2Score { get; set; }
        public int ot3Score { get; set; }
        public int ot4Score { get; set; }
        public int ot5Score { get; set; }
        public int ot6Score { get; set; }
        public int ot7Score { get; set; }
        public int ot8Score { get; set; }
        public int ot9Score { get; set; }
        public int pointsInPaint { get; set; }
        public int pointsOffTurnovers { get; set; }
        public int q1Score { get; set; }
        public int q2Score { get; set; }
        public int q3Score { get; set; }
        public int q4Score { get; set; }
        public int rebs { get; set; }
        public int score { get; set; }
        public int seconds { get; set; }
        public int shortTimeoutsRemaining { get; set; }
        public int steals { get; set; }
        public int technicalFouls { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class Matchup2
    {
        public string confRank { get; set; }
        public string divRank { get; set; }
        public string losses { get; set; }
        public object seriesText { get; set; }
        public string wins { get; set; }
    }

    public class Profile10
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class Boxscore3
    {
        public string dnpReason { get; set; }
        public string isStarter { get; set; }
        public string onCourt { get; set; }
        public string plusMinus { get; set; }
        public string position { get; set; }
    }

    public class StatTotal5
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class GamePlayer2
    {
        public Profile10 profile { get; set; }
        public Boxscore3 boxscore { get; set; }
        public StatTotal5 statTotal { get; set; }
    }

    public class Profile11
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal6
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class PointGameLeader2
    {
        public Profile11 profile { get; set; }
        public StatTotal6 statTotal { get; set; }
    }

    public class Profile12
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal7
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class AssistGameLeader2
    {
        public Profile12 profile { get; set; }
        public StatTotal7 statTotal { get; set; }
    }

    public class Profile13
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatTotal8
    {
        public int assists { get; set; }
        public int blocks { get; set; }
        public int defRebs { get; set; }
        public int fga { get; set; }
        public int fgm { get; set; }
        public double fgpct { get; set; }
        public int fouls { get; set; }
        public int fta { get; set; }
        public int ftm { get; set; }
        public double ftpct { get; set; }
        public int mins { get; set; }
        public int offRebs { get; set; }
        public int points { get; set; }
        public int rebs { get; set; }
        public int secs { get; set; }
        public int steals { get; set; }
        public int tpa { get; set; }
        public int tpm { get; set; }
        public double tppct { get; set; }
        public int turnovers { get; set; }
    }

    public class ReboundGameLeader2
    {
        public Profile13 profile { get; set; }
        public StatTotal8 statTotal { get; set; }
    }

    public class Profile14
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatAverage4
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class PointSeasonLeader2
    {
        public Profile14 profile { get; set; }
        public StatAverage4 statAverage { get; set; }
    }

    public class Profile15
    {
        public string code { get; set; }
        public string country { get; set; }
        public string displayAffiliation { get; set; }
        public string displayName { get; set; }
        public string displayNameEn { get; set; }
        public string dob { get; set; }
        public string draftYear { get; set; }
        public string experience { get; set; }
        public string firstInitial { get; set; }
        public string firstName { get; set; }
        public string firstNameEn { get; set; }
        public string height { get; set; }
        public string jerseyNo { get; set; }
        public string lastName { get; set; }
        public string lastNameEn { get; set; }
        public string leagueId { get; set; }
        public string playerId { get; set; }
        public string position { get; set; }
        public string schoolType { get; set; }
        public string weight { get; set; }
    }

    public class StatAverage5
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class AssistSeasonLeader2
    {
        public Profile15 profile { get; set; }
        public StatAverage5 statAverage { get; set; }
    }

    public class StatAverage6
    {
        public double assistsPg { get; set; }
        public double blocksPg { get; set; }
        public double defRebsPg { get; set; }
        public double efficiency { get; set; }
        public double fgaPg { get; set; }
        public double fgmPg { get; set; }
        public double fgpct { get; set; }
        public double foulsPg { get; set; }
        public double ftaPg { get; set; }
        public double ftmPg { get; set; }
        public double ftpct { get; set; }
        public int games { get; set; }
        public int gamesStarted { get; set; }
        public double minsPg { get; set; }
        public double offRebsPg { get; set; }
        public double pointsPg { get; set; }
        public double rebsPg { get; set; }
        public double stealsPg { get; set; }
        public double tpaPg { get; set; }
        public double tpmPg { get; set; }
        public double tppct { get; set; }
        public double turnoversPg { get; set; }
    }

    public class ReboundSeasonLeader2
    {
        public object profile { get; set; }
        public StatAverage6 statAverage { get; set; }
    }

    public class AwayTeam
    {
        public Profile9 profile { get; set; }
        public Standing2 standing { get; set; }
        public Score2 score { get; set; }
        public Matchup2 matchup { get; set; }
        public List<GamePlayer2> gamePlayers { get; set; }
        public PointGameLeader2 pointGameLeader { get; set; }
        public AssistGameLeader2 assistGameLeader { get; set; }
        public ReboundGameLeader2 reboundGameLeader { get; set; }
        public PointSeasonLeader2 pointSeasonLeader { get; set; }
        public AssistSeasonLeader2 assistSeasonLeader { get; set; }
        public ReboundSeasonLeader2 reboundSeasonLeader { get; set; }
    }

    public class League
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Season
    {
        public string isCurrent { get; set; }
        public int rosterSeasonType { get; set; }
        public string rosterSeasonYear { get; set; }
        public string rosterSeasonYearDisplay { get; set; }
        public int scheduleSeasonType { get; set; }
        public string scheduleSeasonYear { get; set; }
        public string scheduleYearDisplay { get; set; }
        public int statsSeasonType { get; set; }
        public string statsSeasonYear { get; set; }
        public string statsSeasonYearDisplay { get; set; }
        public string year { get; set; }
        public string yearDisplay { get; set; }
    }

    public class Payload
    {
        public GameProfile gameProfile { get; set; }
        public Boxscore boxscore { get; set; }
        public List<Url> urls { get; set; }
        public List<object> broadcasters { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public League league { get; set; }
        public Season season { get; set; }
    }

    public class RootObject
    {
        public Context context { get; set; }
        public Error error { get; set; }
        public Payload payload { get; set; }
        public string timestamp { get; set; }
    }
}
