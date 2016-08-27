chatApp.config(function ($routeProvider) {
    $routeProvider

        .when('/home', {
            templateUrl: 'app/home/home.html',
            controller: 'homeController'
        }).
        otherwise({
            redirectTo: '/home'
        });
});