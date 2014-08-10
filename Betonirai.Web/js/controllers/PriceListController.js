'use strict';

ngApp.controller('PriceListController',
    function PriceListController($scope, priceListData) {
        $scope.priceList = priceListData.getPriceList(1);
    });