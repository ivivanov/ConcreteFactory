'use strict';

ngApp.controller('ContactsController',
    function ContactsController($scope) {
        $scope.privateKey = "6Lc-kPQSAAAAAJVg0bbCgz3BtYbW4-bmooFYXxnm";
        $scope.email = "";
        $scope.textArea = "";
        $scope.recaptchamodel = "1";
        // defaults for your business location and blurb
        var Location = new google.maps.LatLng(42.6707206, 23.32162679999999);
        var infoWindow = "<b>Tuka sum si doma :D</b><br/>Krichim 1<br/>1407 Sofia";
        var markerHoverTitle = "Te tuka";
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay = new google.maps.DirectionsRenderer({
            draggable: true
        });

        var mapOptions = {
            center: Location,
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

        var infowindow = new google.maps.InfoWindow({
            content: infoWindow
        });

        var marker = new google.maps.Marker({
            position: Location,
            map: map,
            title: markerHoverTitle,
            animation: google.maps.Animation.DROP
        });
        // show info Window
        var infowindow = new google.maps.InfoWindow({
            content: infoWindow
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });

        infowindow.open(map, marker);

        // Submit button action
        $scope.sendMail = function (form) {
            debugger
            var x = $scope.recaptchamodel;
            //recaptchaService.checkRecaptcha
        }
    }); 