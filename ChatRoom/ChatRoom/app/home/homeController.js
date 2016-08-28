
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams',
        function (dataFactory, $scope, $routeParams) {

	    $scope.title = "Home";

        function getMock() {
            return dataFactory.getMock().then(function(response) {
                console.log(response);
            }, function(error) {
                console.log(error);
            });
        }

        function activited() {
            // Wait for the http responses
            console.log($scope.title + 'activited');
            getMock();
        }

        activited();
}]);