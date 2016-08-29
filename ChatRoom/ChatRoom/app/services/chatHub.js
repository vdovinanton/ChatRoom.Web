
chatApp.factory('chatHub', function () {
        
        var chatFactory = {};

        chatFactory.connect = function () {
            $.connection.hub.start();
        }

        chatFactory.send = function(data) {
            $.connection.chatHub.server.sendMessage(data);
        }

        chatFactory.on = function (callback) {
            $.connection.chatHub.client.broadcastMessage = function (data) {
                callback(data);
            }
        }

        return chatFactory;
    });

