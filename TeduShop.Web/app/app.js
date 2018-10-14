﻿/// <reference path="../asset/admin/libs/angular/angular.js" />

(function () {
    angular.module("tedushop", [
        'tedushop.product_categories'
        , 'tedushop.products'
        , 'tedushop.common']).config(config);

    config.$inject = ["$stateProvider", '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });

        $urlRouterProvider.otherwise('/admin');
    }
})();