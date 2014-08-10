'use strict';

ngApp.controller('Step3Controller',
    function Step3Controller($scope, orderDetails) {
        $scope.step = '100%';
        $scope.statePrev = '';
        $scope.previous = 'calculator/step2';
        $scope.from = 'Бетонов Възел "BetMax". Чепинско шосе 44, София';
        $scope.to = orderDetails.to.one + ' ' + orderDetails.to.two + ' ' + orderDetails.to.three;
        $scope.distance = orderDetails.distance;
        $scope.item = orderDetails.items[orderDetails.selectedItem].name;
        $scope.quantity = orderDetails.quantity;
        var measureStr = '';
        if (orderDetails.measure == 'kg') {
            measureStr = 'кг';
        }
        if (orderDetails.measure == 'ton') {
            measureStr = 'тон';
        }
        $scope.measure = measureStr;
        $scope.deliveryDate = orderDetails.deliveryDate;
        $scope.deliveryTime = orderDetails.deliveryTime;
        $scope.email = orderDetails.email;
        $scope.phone = orderDetails.phone;
        $scope.comment = orderDetails.comment;
    });

