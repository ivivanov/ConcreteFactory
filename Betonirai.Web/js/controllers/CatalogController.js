'use strict';

ngApp.controller('CatalogController',
    function CatalogController($scope, $route, $routeParams, priceListData) {
        var priceList = priceListData.getPriceList($routeParams.id);
        $scope.priceList = priceList.items;
        $scope.title = priceList.title;
        $scope.isActive = function (id) {
            return id === $routeParams.id;
        };
    });