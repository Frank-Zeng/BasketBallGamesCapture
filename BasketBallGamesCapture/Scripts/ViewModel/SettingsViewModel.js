var setting = {};

var settingVM = function () {
    var self = this;

    self.isLoadingdata = ko.observable(false);
    self.homeTwoPValue = ko.observable("52");
    self.visitTwoPValue = ko.observable("50");

    self.homeThreePValue = ko.observable("38");
    self.visitThreePValue = ko.observable("35");

    self.homeFreeTValue = ko.observable("85");
    self.visitFreeTValue = ko.observable("80");
}


$(function () {
    setting = new settingVM();
    ko.applyBindings(setting, document.getElementById("settingPanel"));
});
