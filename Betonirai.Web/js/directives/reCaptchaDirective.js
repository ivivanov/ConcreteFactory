'use strict';

ngApp.directive('recaptcha', function () {

    return {
        restrict: 'A',
        transclude: true,
        compile: function (element, attributes) {
            Recaptcha.create("6Lc-kPQSAAAAAJVg0bbCgz3BtYbW4-bmooFYXxnm", attributes.id, {
                theme: "clean",
                callback: function () {
                    Recaptcha.focus_response_field;
                }
            });
        }
    }
})