'use strict';

ngApp.service('recaptchaService', function ($http, $q) {

    function checkRecaptcha(recaptchaParams) {

        var request = $http({
            method: "post",
            url: "http://betonirai.azurewebsites.net/api/ReCaptcha",
            data: recaptchaParams
        });

        return (request.then(handleSuccess, handleError));
    }

    return {
        checkRecaptcha: checkRecaptcha
    };
    
});