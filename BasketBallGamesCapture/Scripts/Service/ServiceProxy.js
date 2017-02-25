var ServiceProxy = (function (url) {

    /** 
     *  @description Create a low level HTTP Proxy using an URL.
     *  @param {string} url The service URL.
     */
    function ServiceProxy(url) {
        this.url = url;
    };

    /** 
     *  @description Transfer Object Data using HTTP protocol.
     *  @param {string} method The API URL.
     *  @param {string} httpMethod The HTTP Method, such as: GET,POST,DELETE,PUT and so on.
     *  @param {object} data The data object, such as: BuildItem, FeatureItem and so on.
     *  @param {function} customBeforeSend The function before Ajax send call.
     *  @param {function} successCallback The function when Ajax send successfully call.
     *  @param {function} errorCallback The function when Ajax send failed call.
     */
    ServiceProxy.prototype.sendRequest = function (method, httpMethod, data, customBeforeSend, successCallback, errorCallback) {
        var self = this;

        $.ajax({
            type: httpMethod,
            contentType: "application/json;charset=UTF-8",
            crossDomain: true,
            datatype: "json",
            url: this.url + method,
            data: data != null ? data : {},
            cache: false,
            beforeSend: function (xhr) {
                if (customBeforeSend != null) {
                    customBeforeSend();
                };
            },
            success: function (data) {
                if (successCallback != null) {
                    successCallback(data);
                }
            },
            error: function (xhr, status, error) {
                console.log(error);

                if (!errorCallback) {
                    errorCallback();
                }
            }
        });
    };

    /** 
     *  @description Get object data in JSON format using HTTP GET method.
     *  @param {string} method The API URL.
     *  @param {function} beforeSend The function before Ajax send call.
     *  @param {function} successCallback The function when Ajax send successfully call.
     *  @param {function} errorCallback The function when Ajax send failed call.
     */
    ServiceProxy.prototype.get = function (method, beforeSend, successCallback, errorCallback) {
        this.sendRequest(method, "GET", null, beforeSend, successCallback, errorCallback);
    };

    /** 
     *  @description Post object data in JSON format using HTTP POST method.
     *  @param {string} method The API URL.
     *  @param {function} beforeSend The function before Ajax send call.
     *  @param {function} successCallback The function when Ajax send successfully call.
     *  @param {function} errorCallback The function when Ajax send failed call.
     */
    ServiceProxy.prototype.post = function (method, data, beforeSend, successCallback, errorCallback) {
        this.sendRequest(method, "POST", data, beforeSend, successCallback, errorCallback);
    };

    return ServiceProxy;
})();
