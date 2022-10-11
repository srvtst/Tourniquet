using Core.RabbitMQ.Abstract;
using Entities.Concrate;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    public class ConsumerManager : IConsumerService
    {
        IRabbitMQService _rabbitMqService;
        public ConsumerManager(IRabbitMQService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void Start(Tourniquet tourniquet)
        {
            using (var connection = _rabbitMqService.GetConnection())
            {
                using (var channel = _rabbitMqService.GetModel(connection))
                {
                    channel.QueueDeclare(queue: "Tourniquet",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = JsonConvert.SerializeObject(body);
                        tourniquet = JsonConvert.DeserializeObject<Tourniquet>(message);
                    };

                    channel.BasicConsume(
                        queue: "Tourniquet", autoAck: true, consumer: consumer);
                }
            }
        }
    }
}