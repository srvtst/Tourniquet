using Core.RabbitMQ.Abstract;
using Entities.Concrate;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    public class PublisherManager : IPublisherService
    {
        IRabbitMQService _rabbitMQService;
        public PublisherManager(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        public void Enqueue(Tourniquet tourniquet)
        {
            using (var connection = _rabbitMQService.GetConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Tourniquet",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tourniquet));
                channel.BasicPublish(exchange: "",
                                     routingKey: "Tourniquet",
                                     body: body,
                                     basicProperties: channel.CreateBasicProperties());
            }
        }
    }
}