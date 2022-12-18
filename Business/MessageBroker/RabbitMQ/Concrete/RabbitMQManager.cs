using Business.MessageBroker.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Business.MessageBroker.RabbitMQ.Concrete
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
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = _rabbitConfiguration.Uri
            };

            return connectionFactory.CreateConnection();
        }
        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}