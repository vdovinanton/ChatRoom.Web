
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams',
        function (dataFactory, $scope, $routeParams) {

	    $scope.title = "Home";

        function getMock() {
            return dataFactory.getUsers().then(function (response) {
                console.log(response.data);
            }, function(error) {
                console.log(error);
            });
        }

        function activited() {
            // Wait for the http responses
            $.connection.hub.start(); // starts hub
            console.log($scope.title + 'activited');
            getMock();
        }
        
        // scope variables
        $scope.name = 'Guest'; // holds the user's name
        $scope.message = ''; // holds the new message
        $scope.messages = []; // collection of messages coming from server
        $scope.chatHub = null; // holds the reference to hub

        $scope.chatHub = $.connection.chatHub; // initializes hub

            // register a client method on hub to be invoked by the server
        $.connection.chatHub.client.broadcastMessage = function (name, message) {
            var newMessage = name + ' says: ' + message;

            // push the newly coming message to the collection of messages
            $scope.messages.push(newMessage);
            console.log($scope.messages);
            $scope.$apply();
        };

        $scope.newMessage = function () {
            // sends a new message to the server
            $scope.chatHub.server.sendMessage($scope.name, $scope.message);

            $scope.message = '';
        }

        activited();
}]);