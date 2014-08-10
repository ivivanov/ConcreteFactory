'use strict';

ngApp.controller('Step1Controller',
    function Step1Controller($scope, orderDetails) {
        //CONSTANTS
        $scope.step = '33%';
        $scope.statePrev = 'disabled';
        $scope.stateNext = '';
        $scope.next = 'calculator/step2';
        $scope.previous = '';

        //VARIABLES
        var destinationAddress = "Sofia, България";
        var Location = new google.maps.LatLng(42.743248, 23.409862);
        var businessWriteup = "<b>Бетонов възел</b><br/>Beta max<br/>";
        var defaultFromAddress = new google.maps.LatLng(42.743248, 23.409862);
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay = new google.maps.DirectionsRenderer({ draggable: false });
        var mapOptions = {
            center: Location,
            zoom: 17,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("step1_map"), mapOptions);
        var inputAutocomplete = document.getElementById('adress-input');
        var autocomplete = new google.maps.places.Autocomplete(inputAutocomplete);
        var contentString = businessWriteup;
        var geocoder = new google.maps.Geocoder();
        //var marker = new google.maps.Marker({
        //    position: Location,
        //    map: map,
        //    title: businessTitle,
        //    animation: google.maps.Animation.DROP
        //});

        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });

        //$SCOPE VARIABLES
        $scope.destinationAddress = "";
        $scope.totalKm = 0;

        //UPDATE orederDetails
        orderDetails.to = destinationAddress;
        orderDetails.distance = $scope.totalKm;
        $scope.$watch('destinationAddress', function (newValue) {
            orderDetails.to = destinationAddress;
        });
        $scope.$watch('totalKm', function (newValue) {
            orderDetails.distance = $scope.totalKm
        });

        //INITIAL STARTERS
        //infowindow.open(map, marker);
        directionsDisplay.setMap(map);
        setDirections();

        // EVENT LISTENERS
        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            destinationAddress = autocomplete.getPlace().geometry.location;
            setDirections();

            //update order details
            geocoder.geocode({ 'latLng': destinationAddress }, function (results, status) {

                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[0]) {
                        orderDetails.to = {
                            one: results[0].formatted_address ? results[0].formatted_address : 'Няма информация',
                            two: results[1].formatted_address ? results[1].formatted_address : 'Няма информация',
                            three: results[2].formatted_address ? results[2].formatted_address : 'Няма информация',
                            four: results[3].formatted_address ? results[3].formatted_address : 'Няма информация',
                            five: results[4].formatted_address ? results[4].formatted_address : 'Няма информация',
                            six: results[5].formatted_address ? results[5].formatted_address : 'Няма информация',
                            seven: results[6].formatted_address ? results[6].formatted_address : 'Няма информация',
                        };
                    }
                } else {
                    orderDetails.to = "невалиден адрес";
                }
            });
        });

        //google.maps.event.addListener(marker, 'click', function () {
        //    infowindow.open(map, marker);
        //});

        google.maps.event.addListener(directionsDisplay, 'directions_changed', function () {
            computeTotalDistance(directionsDisplay.directions);
            try {
                if (directionsDisplay.directions.routes[0].legs[0]) {

                    $scope.$apply(function () {
                        $scope.fromAddress = directionsDisplay.directions.routes[0].legs[0].start_address;
                    });
                }
            } catch (e) { }
        });

        // FUNCTIONS
        function setDirections() {
            var selectedMode = 'DRIVING',
                from = $scope.fromAddress || defaultFromAddress,
                request = {
                    origin: from,
                    destination: destinationAddress,
                    travelMode: selectedMode,
                    provideRouteAlternatives: true,
                    unitSystem: google.maps.UnitSystem.METRIC,
                    optimizeWaypoints: true
                };

            directionsService.route(request, function (response, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    //showPointAMarker(response);
                } else {
                    alert("Въведете валиден адрес");
                }
            });
        }

        function computeTotalDistance(result) {
            var total = 0, i,
                myroute = result.routes[0];
            for (i = 0; i < myroute.legs.length; i++) {
                total += myroute.legs[i].distance.value;
            }
            total = total / 1000;
            $scope.$apply(function () {
                $scope.totalKm = total;
            });
        }

        //function showPointAMarker(directionResult) {
        //    // For each step, place a marker, and add the text to the marker's
        //    // info window. Also attach the marker to an array so we
        //    // can keep track of it and remove it when calculating new
        //    // routes.
        //    var myRoute = directionResult.routes[0].legs[0];
        //    var pointA = myRoute[0];
        //    console.log(pointA);
        //    for (var i = 0; i < myRoute.steps.length; i++) {
        //        var marker = new google.maps.Marker({
        //            position: myRoute.steps[i].start_point,
        //            map: map
        //        });
        //        attachInstructionText(marker, myRoute.steps[i].instructions);
        //        markerArray[i] = marker;
        //    }
        //}

        //function attachInstructionText(marker, text) {
        //    google.maps.event.addListener(marker, 'click', function () {
        //        stepDisplay.setContent(text);
        //        stepDisplay.open(map, marker);
        //    });
        //}
    });

