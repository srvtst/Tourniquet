using Core.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _configuration { get; }
        private RabbitConfiguration _rabbitConfiguration;
        public RabbitMQManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _rabbitConfiguration = _configuration.GetSection("RabbitMQ").Get<RabbitConfiguration>();
        }

        public IConnection GetConnection()
        {
            //rabbitmq hostuna bağlantı
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _rabbitConfiguration.HostName,
                UserName = _rabbitConfiguration.UserName,
                Password = _rabbitConfiguration.Password,
                Port = _rabbitConfiguration.Port,
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