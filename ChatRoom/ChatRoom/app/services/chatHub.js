
chatApp.factory('chatHub', function () {
        
        var chatFactory = {};

        chatFactory.connect = function () {
            return $.connection.hub.start();
        }

        chatFactory.stop = function () {
            return $.connection.hub.stop();
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

