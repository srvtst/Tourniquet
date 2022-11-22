using Business.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Business.RabbitMQ.Concrate
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
                HostName = _rabbitConfiguration.HostName,
                UserName = _rabbitConfiguration.UserName,
                Password = _rabbitConfiguration.Password,
                Port = _rabbitConfiguration.Port,
            };

            return connectionFactory.CreateConnection();
        }
        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}