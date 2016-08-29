
chatApp.factory('chatHub', function () {
        
        var chatFactory = {};

        chatFactory.connect = function () {
            $.connection.hub.start();
        }

        chatFactory.send = function(name, message) {
            $.connection.chatHub.server.sendMessage(name, message);
        }

        chatFactory.on = function (callback) {
            $.connection.chatHub.client.broadcastMessage = function (name, message) {
                callback(name, message);
            }
        }

        return chatFactory;
    });

