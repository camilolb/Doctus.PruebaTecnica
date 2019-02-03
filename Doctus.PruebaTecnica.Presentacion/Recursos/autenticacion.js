(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("AutenticacionController", function ($scope, $window, $location, AutenticacionService) {

        $scope.credenciales = {};
        $scope.enableLogin = false;
        $scope.getUsuarioLogeado = {};


        $scope.login = function (credenciales) {

            var respuesta = AutenticacionService.getCurrentUser(credenciales);

            respuesta.then(function (response) {

                //creo la cookie
                $window.sessionStorage.setItem('user', angular.toJson(response));
                alert("¡bienvenido!");

                location.reload();

            }, function (response) {
                alert("Usuario y/o contraseña incorrectos");
            });
        };

    });

    app.service('AutenticacionService', function ($http, $q, $window) {

        this.getCurrentUser = function (credenciales) {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./oauth/check?usuario=' + credenciales.username + "&password=" + credenciales.password, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = e.data;
                response.resolve(resultado);
            };

            function errorCallback(e) {

                var resultado = null;
                response.reject(resultado);
            };

            return response.promise;
        };

        this.logout = function () {

            sessionStorage.clear();
        };

    });

})();