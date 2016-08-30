
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams', 'chatHub',
        function (dataFactory, $scope, $routeParams, chatHub) {

	    $scope.title = "Home";
	    $scope.name = "Guest";
        $scope.imageUr = "";

        $scope.message = {
            SenderName: "",
            Body: "",
            Attachment: ""
        }

            /*$scope.message = {
                senderName: "",
                body: "",
                attachment: ""
            };*/

	    $scope.messages = [];

        function getMock() {
            return dataFactory.getUsers().then(function (response) {
                console.log(response.data);
            }, function(error) {
                console.log(error);
            });
        }

        // find & remove protocol (http, ftp, etc.) and get domain
        function extractDomain(url) {
            var domain;
            if (url.indexOf("://") > -1) {
                domain = url.split('/')[2];
            }
            else {
                domain = url.split('/')[0];
            }
            return domain.split(':')[0];
        }

        // parse url
        function urlify(text) {
            var urlRegex = /(https?:\/\/[^\s]+)/g;
            return text.replace(urlRegex, function (url) {
                return '<a href="' + url + '">' + extractDomain(url) + '</a>';
            });
        }

        // like a start point
        function activited() {
            chatHub.connect();
            getMock();
        }
        
        $scope.newMessage = function () {
            if ($scope.message.Body || $scope.imageUr)
            {
                $scope.fileStyle = { "background-color": "white" }

                var newMessage = {
                    SenderName: $scope.name,
                    Body: urlify($scope.message.Body),
                    Attachment: $scope.imageUr
                }

                /*$scope.message.SenderName = $scope.name;
                $scope.message.Body = urlify($scope.message.Body);
                $scope.message.Attachment = $scope.imageUr;*/

                chatHub.send(newMessage);
                
                $scope.OnButtonImageClick = false;
                $scope.message.Body = "";
                $scope.imageUr = "";
            }
        }

        $scope.upload = function (file) {
            if (file) {
                dataFactory.upload($scope.name, file).then(function (response) {
                    //console.log(response.data);
                    $scope.imageUr = response.data;
                    $scope.fileStyle = { "background-color": "#A9F5A9" }
                }, function(error) {
                    console.log(error);
                    $scope.fileStyle = { "background-color": "#F5A9A9" }
                });
            }
        };
            
        // event on new message
        chatHub.on(function (data) {
            var newMessage = {
                SenderName: data.SenderName,
                Body: data.Body,
                Attachment: data.Attachment
            }

            /*$scope.message.senderName = data.SenderName;
            $scope.message.body = data.Body;
            $scope.message.attachment = data.Attachment;
*/
            $scope.messages.push(newMessage);
            console.log(newMessage);
            $scope.$apply();
        });

        activited();
}]);