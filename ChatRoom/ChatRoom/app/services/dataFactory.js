
chatApp.factory('dataFactory', ['$http', '$upload',
        function ($http, $upload) {

        var dataFactory = {};

        dataFactory.getUsers = function() {
            return $http.get('/api/chat');
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