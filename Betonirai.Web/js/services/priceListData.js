'use strict';

ngApp.factory('priceListData', function($resource) {

    //var resource = $resource('/data/price lists/:id', { id: '@id' });

    var resource = [
    {
        number: 1,
        name: "Dograma",
        color: "blue",
        price: 1.3
    },
    {
        number: 1,
        name: "Dograma",
        color: "blue",
        price: 1.3
    },
    {
        number: 1,
        name: "Dograma",
        color: "blue",
        price: 1.3
    }];

    return {
        getPriceList: function(id) {
            //return resource.get({id: id});
            return resource;
        }
    }
})