'use strict';

ngApp.controller('Step2Controller',
    function Step2Controller($scope, orderDetails) {
        //$SCOPE VARIABLES
        $scope.step = '66%';
        $scope.statePrev = '';
        $scope.stateNext = '';
        $scope.next = 'calculator/step3';
        $scope.previous = 'calculator/step1';
        $scope.items = orderDetails.items;
        $scope.item = orderDetails.items[orderDetails.selectedItem];
        $scope.quantity = orderDetails.quantity;
        $scope.measure = orderDetails.measure;
        $scope.comment = orderDetails.comment;
        $scope.email = orderDetails.email;
        $scope.phone = orderDetails.phone;
        $scope.dt = orderDetails.deliveryDate;
        $scope.mytime = orderDetails.deliveryTime;

        //Update orderDetails
        //orderDetails.item = $scope.item;
        //orderDetails.quantity = $scope.quantity;
        //orderDetails.measure = $scope.measure;
        //orderDetails.comment = $scope.comment;
        //orderDetails.email = $scope.email;
        //orderDetails.phone = $scope.phone;
        //orderDetails.deliveryDate = $scope.dt;
        //orderDetails.deliveryTime = $scope.mytime;
        $scope.$watch('item', function (newValue, oldValue) {
            for (var i = 0; i < orderDetails.items.length; i++) {
                if (orderDetails.items[i].name == newValue.name) {
                    $scope.item = orderDetails.items[i];
                    orderDetails.selectedItem = i;
                }
            }
            //console.log(newValue)
            //console.log(oldValue)
            //orderDetails.selectedItem = $scope.item;
        });
        $scope.$watch('quantity', function (newValue, oldValue) {
            orderDetails.quantity = $scope.quantity;
        });
        $scope.$watch('measure', function (newValue, oldValue) {
            orderDetails.measure = $scope.measure;
        });
        $scope.$watch('comment', function (newValue, oldValue) {
            orderDetails.comment = $scope.comment;
        });
        $scope.$watch('email', function (newValue, oldValue) {
            orderDetails.email = $scope.email;
        });
        $scope.$watch('phone', function (newValue, oldValue) {
            orderDetails.phone = $scope.phone;
        });
        $scope.$watch('dt', function (newValue, oldValue) {
            orderDetails.deliveryDate = $scope.dt;
        });
        $scope.timeChanged = function () {
            orderDetails.deliveryTime = $scope.mytime.hours + $scope.mytime.minutes;
        };


        //Datepicker
        
        // Disable weekend selection
        //$scope.disabled = function (date, mode) {
        //    return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
        //};

        $scope.toggleMin = function () {
            $scope.minDate = $scope.minDate ? null : new Date();
        };
        $scope.toggleMin();

        $scope.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope.opened = true;
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.initDate = new Date('2016-15-20');
        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[0];
        
        //Timepicker
        $scope.hstep = 1;
        $scope.mstep = 15;

        $scope.options = {
            hstep: [1, 2, 3],
            mstep: [1, 5, 10, 15, 25, 30]
        };

        $scope.ismeridian = false;
        $scope.toggleMode = function () {
            $scope.ismeridian = !$scope.ismeridian;
        };
    });

