chatApp.config(function ($routeProvider) {
    $routeProvider

        .when('/home/:id', {
            templateUrl: 'app/home/home.html',
            controller: 'homeController'
        })
        .when('/login', {
            templateUrl: 'app/login/login.html',
            controller: 'loginController'
        }).
        otherwise({
            redirectTo: '/login'
        });
});