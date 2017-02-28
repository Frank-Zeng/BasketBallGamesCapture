﻿var BasketBallGamesCaptureService = (function (serviceUrl) {
    /** 
     *  @description Create a proxy to transfer the service resource.
     *  @param {string} serviceUrl The service's URL
     */
    function BasketBallGamesCaptureService(serviceUrl) {
        this.serviceProxy = new ServiceProxy(serviceUrl);
    };

    BasketBallGamesCaptureService.prototype.getNBAGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetNBAGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getNBAGamesUrls = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetNBAGamesUrls", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getSpecifyGamesData = function (url, successCallback, errorCallback) {
        this.serviceProxy.get("GetSpecifyGamesData/?id=" + url, null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getEuropenGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetEuropenGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getVtbLeagueGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetVtbLeagueGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getACBGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetACBGamesTodayData", null, successCallback, errorCallback);
    };

    BasketBallGamesCaptureService.prototype.getBekoGamesTodayDataList = function (successCallback, errorCallback) {
        this.serviceProxy.get("GetEasyCreditGamesTodayData", null, successCallback, errorCallback);
    };

    return BasketBallGamesCaptureService;
})();

var BasketBallGamesCaptureService = new BasketBallGamesCaptureService("../api/");
