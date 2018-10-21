(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;

            this.login = function (username, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + username + "&password=" + password;
                $http.post('/oauth/token', data, {
                    headers:
                        { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (response) {
                    userInfo = {
                        accessToken: response.access_token,
                        username: username
                    };
                    authenticationService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.username = username;
                    deferred.resolve(null);
                },function (err, status) {
                        authData.authenticationData.IsAuthenticated = false;
                        authData.authenticationData.username = "";
                        deferred.resolve(err);
                    });
                return deferred.promise;
            }

            this.logOut = function () {
                authenticationService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.username = "";
            }
        }]);
})(angular.module('tedushop.common'));