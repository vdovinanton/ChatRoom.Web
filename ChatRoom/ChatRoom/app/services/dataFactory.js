
chatApp.factory('dataFactory', ['$http', '$q', 
        function ($http, $q) {

        var urlBase = '/api/chat';
        var dataFactory = {};

        dataFactory.getUsers = function() {
            return $http.get(urlBase);
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