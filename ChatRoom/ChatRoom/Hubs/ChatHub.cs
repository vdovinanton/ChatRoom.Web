using System.Text;
using ChatRoom.Model;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ConnectionFactory _connection;
        public ChatHub()
        {
            _connection = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
        }

        public void SendMessage(MessageViewModel message)
        {
            Clients.All.broadcastMessage(message);

            using (var connection = _connection.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "test-exchange",
                        type: "fanout",
                        durable: true);

                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "test-exchange",
                        routingKey: "",
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }
}