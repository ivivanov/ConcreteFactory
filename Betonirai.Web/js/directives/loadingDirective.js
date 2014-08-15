'use strict';

ngApp.directive('loading', ['$http', function ($http) {
    return {
        restrict: 'A',
        link: function (scope, elm, attrs) {
            scope.isLoading = function () {
                return $http.pendingRequests.length > 0;
            };
            var hideElements = $(".loading-hide");

            scope.$watch(scope.isLoading, function (v) {
                if (v) {
                    elm.show();
                    hideElements.hide();
                } else {
                    elm.hide();
                    hideElements.show();
                }
            });
        }
    }; 
}]);