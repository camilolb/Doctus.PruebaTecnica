(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("LayoutController", function ($scope, $rootScope, $route, $routeParams, $window, AutenticacionService) {
        $scope.esAnonima;

        $scope.layout = {};
        var loginUsuario = {};

        $scope.layout.url = './Paginas/Login/Index.html';
        
        if (angular.fromJson($window.sessionStorage.getItem('user')) != null
            && angular.fromJson($window.sessionStorage.getItem('user')) != undefined)
        {
            loginUsuario = $window.sessionStorage.getItem('user') || [];
            loginUsuario = JSON.stringify(loginUsuario);

            $scope.getUsuarioLogeado = angular.fromJson(loginUsuario);

            setTimeout(function () {
                $(".login-box").css("display", "none");

                window.location.href = './#/Actividades/Crear';
            }, 1000);
        }


        $scope.$on('$routeChangeStart', function (event, newValue, oldValue) {

            if (newValue !== undefined
                && 'allowAnonymous' in newValue) {

                $scope.layout.url = './Index.html';
            }
        });


        $scope.logout = function ()
        {
            AutenticacionService.logout();
            window.location.href = "./";

        };
    });

})();
