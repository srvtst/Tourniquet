using Business.MessageBroker.RabbitMQ.Abstract;
using Entities.Concrate;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Business.MessageBroker.RabbitMQ.Concrate
{
    public class PublisherManager : IPublisherService
    {
        IRabbitMQService _rabbitMQService;
        public PublisherManager(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        public void Publish(Tourniquet tourniquet)
        {
            using var connection = _rabbitMQService.GetConnection();
            
            using var channel = connection.CreateModel();

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