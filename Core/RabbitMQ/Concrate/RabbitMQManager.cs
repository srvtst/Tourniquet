using Core.RabbitMQ.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    public class RabbitMQManager : IRabbitMQService
    {
        IRabbitMQConfiguration _rabbitMqConfiguration;
        public RabbitMQManager(IRabbitMQConfiguration rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration;
        }

        public IConnection GetConnection()
        {
            //rabbitmq hostuna bağlantı
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.HostName,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password
            };

            return connectionFactory.CreateConnection();
        }

        //rabbitmq üzerinde yeni bir kanal yaratılır.
        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}