chatApp.controller('homeController', ['$scope', '$routeParams',
		function ($scope, $routeParams) {

		    $scope.title = "Home";

		    function activited() {
                // Wait for the http responses
		        console.log($scope.title);
		    }

		    activited();

		}]);