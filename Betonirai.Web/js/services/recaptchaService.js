'use strict';

ngApp.service('recaptchaService', function ($http, $q) {

    function checkRecaptcha(recaptchaParams) {

        var request = $http({
            method: "post",
            url: "api/ReCaptcha",
            params: {
                action: "add"
            },
            data: {
                name: name
            }
        });

        return (request.then(handleSuccess, handleError));
    }

    return {
        checkRecaptcha: checkRecaptcha
    };
    
});