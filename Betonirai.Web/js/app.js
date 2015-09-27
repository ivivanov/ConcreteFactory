'use strict';

var ngApp = angular
    .module('ngApp', ['ngResource', 'ngRoute', 'ui.bootstrap'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', { templateUrl: 'views/home.html' })
            .when('/catalog/:id', { templateUrl: 'views/catalog.html' })
            .when('/contacts', { templateUrl: 'views/contacts.html' })
            //.when('/upload-catalog', { templateUrl: 'views/shared/upload-form.html' })
            //.when('/calculator/step1', { templateUrl: 'views/calculator funnel/step1.html' })
            //.when('/calculator/step2', { templateUrl: 'views/calculator funnel/step2.html' })
            //.when('/calculator/step3', { templateUrl: 'views/calculator funnel/step3.html' })
            .otherwise({ redirectTo: '/home' });
    });
