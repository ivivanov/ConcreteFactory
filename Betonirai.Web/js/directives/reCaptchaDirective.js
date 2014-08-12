'use strict';

ngApp.directive('recaptcha', function () {

    return {
        restrict: 'A',
        transclude: true,
        compile: function (element, attributes) {
            Recaptcha.create("6Lc-kPQSAAAAAJVg0bbCgz3BtYbW4-bmooFYXxnm", attributes.id, {
                theme: "clean",
                callback: function () {
                    $("#recaptcha_response_field").attr("ng-model", "recaptchamodel");

                    $("#recaptcha_response_field").on("blur", function () {

                        console.log($(this));

                    })
                    Recaptcha.focus_response_field;
                }
            });
            return {
                pre: function (scope, element, attributes, controller, transcludeFn) {


                },
                post: function (scope, element, attributes, controller, transcludeFn) {
                    //scope.$watch("recaptchamodel", function (val) {
                    //    console.log(val);

                    //});


                }
            }
        }
    }
})