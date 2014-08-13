'use strict';
//http://betonirai.azurewebsites.net/api/ReCaptcha

ngApp.service('betoniraiWebApi', function ($http, $q) {

    function checkRecaptcha(recaptchaParams) {

        var request = $http({
            method: "post",
            url: "http://localhost:59218/api/ReCaptcha",
            data: recaptchaParams
        });

        return (request.then(handleSuccess, handleError));
    }

    function sendMail(params, handleSuccess, handleError) {

        var request = $http({
            method: "post",
            url: "http://localhost:59218/api/MailSender",
            data: params
        });

        return (request.then(handleSuccess, handleError));
    }

    return {
        checkRecaptcha: checkRecaptcha,
        sendMail: sendMail
    };
    
});