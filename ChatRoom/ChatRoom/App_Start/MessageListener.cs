using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using ChatRoom.Entity;
using ChatRoom.Entity.Entities;
using ChatRoom.Entity.Interfaces;
using ChatRoom.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatRoom.App_Start
{
    /// <summary>
    /// Represent RabbitMQ Bus
    /// http://localhost:15672/#/connections
    /// </summary>
    public class MessageListener
    {
        private IConnection _connection;
        private IModel _channel;
        private IUnitOfWork _repository;

        #region Singleton
        private static readonly Lazy<MessageListener> _instance = new Lazy<MessageListener>(() => new MessageListener());
        public static MessageListener Instance() => _instance.Value;
        #endregion

        public void Start()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _repository = new UnitOfWork(new ChatContext());
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "test-exchange",
                type: "fanout",
                durable: true);

            var queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: queueName,
                exchange: "test-exchange",
                routingKey: "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += ConsumerOnReceived;

            _channel.BasicConsume(queue: queueName,
                noAck: true,
                consumer: consumer);
        }

        public void Stop()
        {
            _channel.Close(200, "Goodbye");
            _connection.Close();
        }

        private void ConsumerOnReceived(object sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var json = Encoding.UTF8.GetString(body);
            var message = JsonConvert.DeserializeObject<MessageViewModel>(json);

            _repository.Users.AddMessages(message.SenderId, message.Body, message.Attachment);
            _repository.Complete();
        }
    }
}