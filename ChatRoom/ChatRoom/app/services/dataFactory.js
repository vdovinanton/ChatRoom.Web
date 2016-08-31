
chatApp.factory('dataFactory', ['$http', '$upload',
        function ($http, $upload) {

        var dataFactory = {};

        dataFactory.getUsers = function() {
            return $http.get('/api/chat/users');
        }

        dataFactory.getUser = function (id) {
            return $http.get('/api/chat/user/' + id);
        }

        dataFactory.getMessages = function () {
            return $http.get('/api/chat/messages/');
        }

        dataFactory.doCreate = function (name) {
            var request = $http({
                method: 'POST',
                url: '/api/chat/create',
                data: {
                    Name: name,
                    Id: ''
                }
            });
            return request;
        }

        dataFactory.upload = function(name, file) {
            return $upload.upload({
                url: 'api/fileUpload/upload',
                fields: { 'username': name },
                file: file
            });
        }

            /*dataFactory.getCustomers = function () {
            return $http.get(urlBase);
        };

        dataFactory.getCustomer = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        dataFactory.insertCustomer = function (cust) {
            return $http.post(urlBase, cust);
        };*/

        return dataFactory;
}]);