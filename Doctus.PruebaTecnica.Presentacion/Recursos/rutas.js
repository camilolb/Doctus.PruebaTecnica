(function () {

    var app = angular.module('pruebaTecnica', ["ngRoute"]);

    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider
            .when("/", {
                templateUrl: "/Index.html"
                , controller: "LayoutController"
            })

            // Crear actividades
            .when("/Actividades/Crear", {
                templateUrl: "./Paginas/Actividades/Crear.html"
                , controller: "ActividadesController"
            })

            // Crear Horas asociadas a la actividad
            .when("/Horas/Crear/:Id", {
                templateUrl: "./Paginas/Horas/Crear.html"
                , controller: "HorasController"
            })
            .otherwise({
                redirectTo: "/"
            });

    });

})();