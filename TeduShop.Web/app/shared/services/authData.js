//cách viết mới tương tự cách viết các module kia
(function (app) {
    'use strict';
    app.factory('authData', [
        function () {
            var authDataFactory = {};

            var authentication = {
                isAuthenticated: false,
                username: ""
            };

            authDataFactory.authenticationData = authentication;

            return authDataFactory;
        }
    ]);
})(angular.module('tedushop.common'));