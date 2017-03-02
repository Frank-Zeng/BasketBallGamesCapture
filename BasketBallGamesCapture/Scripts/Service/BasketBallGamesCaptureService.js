var BasketBallGamesCaptureService = (function (serviceUrl) {
    /** 
     *  @description Create a proxy to transfer the service resource.
     *  @param {string} serviceUrl The service's URL
     */
    function BasketBallGamesCaptureService(serviceUrl) {
        this.serviceProxy = new ServiceProxy(serviceUrl);
    };

    BasketBallGamesCaptureService.prototype.getNBAGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("NBA/GetNBAGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getNBAGamesUrls = function (successCallback, errorCallback) {
        this.serviceProxy.get("NBA/GetNBAGamesUrls", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getSpecifyGamesData = function (url, successCallback, errorCallback) {
        this.serviceProxy.get("NBA/GetGamesData/?id=" + JSON.stringify(url), null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getEuropenGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("Europen/GetEuropenGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getVtbLeagueGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("VtbLeague/GetVtbLeagueGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getACBGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("ACB/GetACBGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getBekoGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("EasyCredit/GetEasyCreditGamesTodayData", null, successCallback, errorCallback);
    };

    return BasketBallGamesCaptureService;
})();

var BasketBallGamesCaptureService = new BasketBallGamesCaptureService("../api/");
