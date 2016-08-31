
chatApp.controller('homeController', ['dataFactory', '$scope', '$routeParams', 'chatHub',
        function (dataFactory, $scope, $routeParams, chatHub) {

	    $scope.title = "Home";
	    $scope.messages = [];
        $scope.message = {
            SenderName: "",
            SenderId: "",
            Body: "",
            Attachment: ""
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

        function getMessageHistory() {
            return dataFactory.getMessages().then(function (response) {
                console.log('history', response);
                $scope.messages.push(response.data);
            }, function (error) {
                
            });
        }

            // like a start point
        function activited() {
            dataFactory.getUser($routeParams.id).then(function (response) {
                chatHub.stop();
                chatHub.connect().done(function () {
                    console.log(response);
                    $scope.message.SenderName = response.data.Name;
                    $scope.message.SenderId = response.data.Id;

                    dataFactory.getMessages().then(function (response) {
                        console.log('history', response);
                        $scope.messages = response.data;
                        /*angular.forEach(response.data, function(value, key) {
                            console.log('value ' + value + 'key ' + key);
                        });*/
                        //$scope.messages.push(response.data);
                    }, function (error) {

                    });

                    $scope.message.Body = $scope.message.SenderName + " has joined to channel";
                    $scope.newMessage();
                });
                console.log(response.data);
            }, function (error) {
                console.log(error);
            });
        }
        
        $scope.newMessage = function () {
            if ($scope.message.Body || $scope.message.Attachment)
            {
                $scope.message.Body = urlify($scope.message.Body);
                console.log($scope.message);
                chatHub.send($scope.message);
                
                $scope.OnButtonImageClick = false;
                $scope.message.Body = "";
                $scope.message.Attachment = "";
            }
        }

        $scope.logout = function () {
            location.href = '/#/';
        }

        $scope.upload = function (file) {
            if (file) {
                dataFactory.upload($scope.message.SenderName, file).then(function (response) {
                    $scope.message.Attachment = response.data;
                    $scope.fileStyle = { "background-color": "#A9F5A9" }
                }, function(error) {
                    console.log(error);
                    $scope.fileStyle = { "background-color": "#F5A9A9" }
                });
            }
        };
            
        // event on new message
        chatHub.on(function (data) {
            var msg = {
                SenderName: data.SenderName,
                Body: data.Body,
                Attachment: data.Attachment
            }
            $scope.messages.push(msg);
            $scope.messages = $scope.messages;
            console.log($scope.messages);
            $scope.$apply();
        });

        activited();
}]);