
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams', 'chatHub', '$upload',
        function (dataFactory, $scope, $routeParams, chatHub, $upload) {

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

        $scope.upload = function (file) {
            if (file) {
                $upload.upload({
                    url: 'api/fileUpload/upload',
                    fields: { 'username': $scope.username },
                    file: file
                }).success(function (data, status, headers, config) {
                    console.log(config);
                    alert("Thanks for the upload!\r\nFilename: " + config.file[0].name + "\r\nResponse: " + data);
                }).error(function (error) {
                    alert("Ooops, something went wrong!");
                    console.log("Error!", error);
                });
            }
        };

        chatHub.on(function(name, message) {
            var newMessage = name + ' says: ' + message;
            $scope.messages.push(newMessage);
            $scope.$apply();
        });

        activited();
}]);