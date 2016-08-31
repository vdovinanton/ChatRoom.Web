
chatApp.controller('loginController', ['dataFactory', '$scope',
        function (dataFactory, $scope) {

            $scope.title = "login";
            $scope.Name = '';
            $scope.currentUser = {
                Name: '',
                Id: ''
            };
            $scope.onCreateChoise = true;

            function getUsers() {
                return dataFactory.getUsers().then(function (response) {
                    $scope.users = response.data;
                    console.log(response);
                }, function (error) {
                    console.log(error);
                });
            }

            $scope.login = function () {
                location.href = '#/home/' + $scope.currentUser.Id;
            }

            $scope.create = function () {
                return dataFactory.doCreate($scope.Name).then(function (response) {
                    location.href = '#/home/' + response.data.Id;
                    console.log(response.data);
                }, function (error) {
                    console.log(error);
                });
            }

            $scope.initUser = function (user) {
                $scope.currentUser = user;
            }

            function activited() {
                getUsers();
            }

            activited();

        }]);