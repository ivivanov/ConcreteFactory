'use strict';

ngApp.controller('CaruselController',
    function CaruselController($scope, $timeout, caruselData) {

        angular.element(document).ready(function () {

            var caruselElement = $("#myCarousel");

            caruselElement
                .carousel({
                    interval: 4000
                });

            $("#nextPic").on('click', function () {
                $("#myCarousel").carousel('next');
            });

            $("#prevPic").on('click', function () {
                $("#myCarousel").carousel('prev');
            });
        });

        var images = caruselData.getImageList();

        $scope.images = images;
    });