(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("HorasController", function ($scope, HorasService, $filter, $http, $routeParams) {

        $scope.hora = {};
        $scope.listaHoras = [];

       // variables globales
        var idActividad = $routeParams.Id;
        $scope.esMasOchoHoras = false;

        // Metodos de carga
        CargarHorasPorActividad(idActividad);


        $scope.crear = function (hora)
        {
            hora.IdActividad = idActividad;
            hora.Fecha = $filter('date')($scope.hora.Fecha, "MM/dd/yyyy");

            var resultado = HorasService.guardar(hora);
            resultado.then(success, error);

            function success(e) {

                var resultado = angular.fromJson(e.data);

                if (resultado
                    && resultado != null)
                {
                    alert("Hora guardada exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar la Hora");
            }
        };




        function CargarHorasPorActividad(idActividad)
        {
            HorasService.obtenerPorId(idActividad).then(function (e)
            {
                var listaHoras = angular.fromJson(e.data);

                if (listaHoras != null
                    && listaHoras.length > 0)
                {
                    var hora = null;

                    for (var i = 0; i < listaHoras.length; i++)
                    {
                        hora += listaHoras[i].Horas;
                    }

                    if (hora >= 8)
                    {
                        $scope.esMasOchoHoras = true;
                    }

                    $scope.listaHoras = listaHoras;
                } else {
                    $scope.listaHoras = "No hay ninguna hora creada recientemente.";
                }
            });
        }



        //  jquery
        $(".calendario").datepicker({
            language: 'es'
        });
    });


    app.service("HorasService", function ($http, $q) {

        this.obtenerPorId = function (id) {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./api/Horas/' + id, data, config).then(successCallback, errorCallback);

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

        this.guardar = function (hora) {

            var response = $q.defer();

            var data = hora;
            var config = {};

            $http.post('./api/Horas', data, config).then(successCallback, errorCallback);

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

    });



})();

