
chatApp.factory('dataFactory', ['$http', '$q', 
        function ($http, $q) {

        var urlBase = '/api/chat';
        var dataFactory = {};

        dataFactory.getMock = function() {
            var data = [
                { id: '1', name: "Vasya" },
                { id: '2', name: 'Petya' }
            ];
            return $q.when(data);
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