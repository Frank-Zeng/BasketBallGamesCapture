var sourceData = {};

var todayVM = function(data){
    var self = this;

    self.GamesCurrentTime = ko.observable(data.GamesCurrentTime);
    self.GamesStartTime = ko.observable(data.GamesStartTime);

    self.HomeTeamName = ko.observable(data.HomeTeamName);
    self.VisitTeamName = ko.observable(data.VisitTeamName);

    self.HomeScore = ko.observable(data.HomeScore);
    self.VisitScore = ko.observable(data.VisitScore);

    self.HomeFG = ko.observable(data.HomeFG);
    self.VisitFG = ko.observable(data.VisitFG);

    self.HomeTwoP = ko.observable(data.HomeTwoP);
    self.VisitTwoP = ko.observable(data.VisitTwoP);

    self.HomeThreeP = ko.observable(data.HomeThreeP);
    self.VisitThreeP = ko.observable(data.VisitThreeP);

    self.HomeFT = ko.observable(data.HomeFT);
    self.VisitFT = ko.observable(data.VisitFT);

    self.HomeOffReb = ko.observable(data.HomeOffReb);
    self.VisitOffReb = ko.observable(data.VisitOffReb);

    self.HomeASS = ko.observable(data.HomeASS);
    self.VisitASS = ko.observable(data.VisitASS);

    self.HomeTO = ko.observable(data.HomeTO);
    self.VisitTO = ko.observable(data.VisitTO);

    self.Alert = ko.observable("P/H");

    self.PTP = ko.observable("143");

    self.HPR = ko.observable("-1.6");
};

var sourceListVM = function(){
    var self = this;

    self.sourceList = ko.observableArray();

    self.getNBATodayData = function () {
        BasketBallGamesCaptureService.getNBAGamesTodayDataList(function (data) {
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
            });
        }, function (error) {
            var x = error;
        });
    };

    self.getEurocupTodayData = function(){
        BasketBallGamesCaptureService.getEuropenGamesTodayDataList(function (data) {

        }, function (error) {

        });
    };

    self.getACBTodayData = function () {
        BasketBallGamesCaptureService.getACBGamesTodayDataList(function (data) {

        }, function (error) {

        });
    };

    self.getVTBLeagueTodayData = function () {
        BasketBallGamesCaptureService.getVtbLeagueGamesTodayDataList(function (data) {

        }, function (error) {

        });
    };

    self.getBekoBBLTodayData = function () {
        BasketBallGamesCaptureService.getBekoGamesTodayDataList(function (data) {

        }, function (error) {

        });
    };
}

$(function () {
    sourceData = new sourceListVM();
    ko.applyBindings(sourceData, document.getElementById("gamesTable"));
});