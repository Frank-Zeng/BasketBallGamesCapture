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

    self.interTime = ko.observable(10000);

    self.sourceList = ko.observableArray();

    self.nbaUrls = ko.observableArray();

    self.getNBATodayUrls = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getNBAGamesUrls(function (data) {
            self.nbaUrls.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.nbaUrls.push(item);
                BasketBallGamesCaptureService.getSpecifyGamesData(item, function (data) {
                    self.sourceList.push(new todayVM(data));
                    setting.isLoadingdata(false);
                }, function (error) {
                    setting.isLoadingdata(false);
                });
            });

        }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
        });
    };

    self.getSpecifyData = function () {
        BasketBallGamesCaptureService.getSpecifyGamesData("0021600883", function (data) {
            self.sourceList.removeAll();
            elf.sourceList.push(new todayVM(data));
            setting.isLoadingdata(false);
        }, function (error) {
            setting.isLoadingdata(false);
        });
    }

    self.getNBATodayData = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getNBAGamesTodayDataList(function (data) {
            self.sourceList.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
                });
            setting.isLoadingdata(false);
            }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
            });
        //setInterval(function () {
        //    setting.isLoadingdata(true);
        //    BasketBallGamesCaptureService.getNBAGamesTodayDataList(function (data) {
        //        self.sourceList.removeAll();
        //    ko.utils.arrayForEach(data, function (item, index) {
        //        self.sourceList.push(new todayVM(item));
        //    });
        //    setting.isLoadingdata(false);
        //}, function (error) {
        //    var x = error;
        //    setting.isLoadingdata(false);
        //});
        //}, self.interTime());
    };



    self.getEurocupTodayData = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getEuropenGamesTodayDataList(function (data) {
            self.sourceList.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
                });
            setting.isLoadingdata(false);
            }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
            });
        //setInterval(function () {
        //    setting.isLoadingdata(true);
        //    BasketBallGamesCaptureService.getEuropenGamesTodayDataList(function (data) {
        //        self.sourceList.removeAll();
        //    ko.utils.arrayForEach(data, function (item, index) {
        //        self.sourceList.push(new todayVM(item));
        //    });
        //    setting.isLoadingdata(false);
        //}, function (error) {
        //    var x = error;
        //    setting.isLoadingdata(false);
        //});
        //}, self.interTime());
    };

    self.getACBTodayData = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getACBGamesTodayDataList(function (data) {
            self.sourceList.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
            });
            setting.isLoadingdata(false);
        }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
        });
        //setInterval(function () {
        //    setting.isLoadingdata(true);
        //    BasketBallGamesCaptureService.getACBGamesTodayDataList(function (data) {
        //        self.sourceList.removeAll();
        //        ko.utils.arrayForEach(data, function (item, index) {
        //            self.sourceList.push(new todayVM(item));
        //        });
        //        setting.isLoadingdata(false);
        //    }, function (error) {
        //        var x = error;
        //        setting.isLoadingdata(false);
        //    });
        //}, self.interTime());
    };

    self.getVTBLeagueTodayData = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getVtbLeagueGamesTodayDataList(function (data) {
            self.sourceList.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
            });
            setting.isLoadingdata(false);
        }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
        });
        //setInterval(function () {
        //    setting.isLoadingdata(true);
        //    BasketBallGamesCaptureService.getVtbLeagueGamesTodayDataList(function (data) {
        //        self.sourceList.removeAll();
        //        ko.utils.arrayForEach(data, function (item, index) {
        //            self.sourceList.push(new todayVM(item));
        //        });
        //        setting.isLoadingdata(false);
        //    }, function (error) {
        //        var x = error;
        //        setting.isLoadingdata(false);
        //    });
        //}, self.interTime());
    };

    self.getBekoBBLTodayData = function () {
        setting.isLoadingdata(true);
        BasketBallGamesCaptureService.getBekoGamesTodayDataList(function (data) {
            self.sourceList.removeAll();
            ko.utils.arrayForEach(data, function (item, index) {
                self.sourceList.push(new todayVM(item));
            });
            setting.isLoadingdata(false);
        }, function (error) {
            var x = error;
            setting.isLoadingdata(false);
        });
        //setInterval(function () {
        //    setting.isLoadingdata(true);
        //    BasketBallGamesCaptureService.getBekoGamesTodayDataList(function (data) {
        //        self.sourceList.removeAll();
        //        ko.utils.arrayForEach(data, function (item, index) {
        //            self.sourceList.push(new todayVM(item));
        //        });
        //        setting.isLoadingdata(false);
        //    }, function (error) {
        //        var x = error;
        //        setting.isLoadingdata(false);
        //    });
        //}, self.interTime());
    };
}

$(function () {
    sourceData = new sourceListVM();
    ko.applyBindings(sourceData, document.getElementById("gamesTable"));
});