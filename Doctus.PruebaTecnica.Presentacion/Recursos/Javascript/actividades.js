(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("ActividadesController", function ($scope, ActividadService) {

        $scope.actividad = {};
        $scope.listaActividades = [];

        // Metodos de carga
        CargarActividades();

        $scope.crear = function (actividad)
        {
            var resultado = ActividadService.guardar(actividad);
            resultado.then(success, error);

            function success(e) {

                var resultado = angular.fromJson(e.data);

                if (resultado
                    && resultado != null)
                {
                    alert("Actividad guardada exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar la actividad");
            }
        };

        $scope.eliminar = function (actividad) {

            if (actividad != null
                && actividad != undefined)
            {
                var resultado = ActividadService.eliminar(actividad);
                resultado.then(success, error);

                function success(e) {
                    alert("Actividad eliminada exitosamente");
                    location.reload();
                };

                function error(e) {
                    alert("Error al eliminar la actividad");
                }
            }

        };



        function CargarActividades()
        {
            ActividadService.obtenerActividades().then(function (e)
            {
                var listaActividades = angular.fromJson(e.data);

                if (listaActividades != null
                    && listaActividades.length > 0)
                {
                    $scope.listaActividades = listaActividades;
                } else {
                    $scope.listaClientes = "No hay ninguna actividad creada recientemente.";
                }
            });
        }
    });


    app.service("ActividadService", function ($http, $q) {

        this.obtenerActividades = function () {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./api/Actividad', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);
            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);
            };

            return response.promise;
        }

        this.guardar = function (actividad) {

            var response = $q.defer();

            var data = actividad;
            var config = {};

            $http.post('./api/Actividad', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };

        this.eliminar = function (actividad) {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.delete('./api/Actividad/' + actividad.Id, data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = e.data;
                response.resolve(resultado);
            };

            function errorCallback(e) {

                var resultado = e.data;
                response.reject(resultado);
            };

            return response.promise;

        };

    });



})();

