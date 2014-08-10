'use strict';

ngApp.factory('caruselData', function () {

    var resource = [
        {
            id: 0,
            isActive: "active",
            imageSource: "img/pic1.jpg",
            description: "Cras justo odio, dapibus ac facilisis in, eged elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
            header: "Heavy truck rental."
        },
        {
            id: 1,
            isActive: "",
            imageSource: "img/pic2.jpg",
            description: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non.",
            header: "Heavy truck rental."
        },
        {
            id: 2,
            isActive: "",
            imageSource: "img/pic3.jpg",
            description: "Cras justo odio, dllam id dolor id nibh ultricies vehicula ut id elit.",
            header: "Heavy truck rental."
        }
    ];

    return {
        getImageList: function () {
            return resource;
        }
    };
});