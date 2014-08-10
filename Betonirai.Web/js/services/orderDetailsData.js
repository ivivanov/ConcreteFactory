'use strict';

ngApp.factory('orderDetails', function () {
    return {
        to: {},
        distance: 0,
        selectedItem: 0,
        items: [
            { name: "Цимент" },
            { name: "Бетон" },
            { name: "Пясък" }
        ],
        quantity: 1,
        measure: 'kg',
        comment: '',
        email: '',
        phone: '',
        deliveryDate: new Date(),
        deliveryTime: new Date(),
        orderDate: '',
        orderTime: '',
    };
});