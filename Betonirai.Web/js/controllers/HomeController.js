'use strict';

ngApp.controller('HomeController',
    function HomeController($scope, $timeout, homeData) {
        var images = homeData.getImageList();
    });