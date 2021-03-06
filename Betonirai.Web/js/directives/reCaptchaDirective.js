﻿'use strict';

ngApp.directive('recaptcha', function () {

    return {
        restrict: 'A',
        transclude: true,
        compile: function (element, attributes) {
            Recaptcha.create("6LdRxfcSAAAAAKvK_pwf9QgP8jA8vipAk-yqazdH", attributes.id, {
                theme: "clean",
                callback: function () {
                    Recaptcha.focus_response_field;
                }
            });
        }
    }
})