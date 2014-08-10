'use strict';

ngApp.directive('recaptcha', function () {

    function link(scope, element, attrs) {

        debugger
        Recaptcha.create(scope.privateKey, attrs.id,
           {
               theme: "clean",
               callback: Recaptcha.focus_response_field
           }
         );
    }

    return {
        restrict: 'A',
        transclude: true,
        link: link
    }
})