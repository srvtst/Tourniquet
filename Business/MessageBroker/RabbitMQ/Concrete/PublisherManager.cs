using Business.MessageBroker.RabbitMQ.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Business.MessageBroker.RabbitMQ.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IRabbitMQService _rabbitMQService;
        ILogger<PublisherManager> _logger;
        public PublisherManager(IRabbitMQService rabbitMQService,ILogger<PublisherManager> logger)
        {
            _rabbitMQService = rabbitMQService;
            _logger = logger;
        }
        public void Publish(Tourniquet tourniquet)
        {
            using var connection = _rabbitMQService.GetConnection();
            
            using var channel = connection.CreateModel();

            _logger.LogInformation("RabbitMQ ile bağlantı kuruldu.");

            channel.QueueDeclare(queue: "Tourniquet",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = JsonSerializer.Serialize(tourniquet);

            var byteBody = Encoding.UTF8.GetBytes(body);

            var properties = channel.CreateBasicProperties();

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "Tourniquet",
                                 body: byteBody,
                                 basicProperties: properties);
        }
    }
}