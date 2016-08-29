
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams', 'chatHub',
        function (dataFactory, $scope, $routeParams, chatHub) {

	    $scope.title = "Home";
	    $scope.name = "Guest";
	    $scope.message = "";
	    $scope.messages = [];

        function getMock() {
            return dataFactory.getUsers().then(function (response) {
                console.log(response.data);
            }, function(error) {
                console.log(error);
            });
        }

        function activited() {
            chatHub.connect();
            console.log($scope.title + 'activited');
            getMock();
        }
        
        $scope.newMessage = function () {
            chatHub.send($scope.name, $scope.message);
            $scope.message = '';
        }

        chatHub.on(function(name, message) {
            var newMessage = name + ' says: ' + message;
            $scope.messages.push(newMessage);
            $scope.$apply();
        });

        activited();
}]);