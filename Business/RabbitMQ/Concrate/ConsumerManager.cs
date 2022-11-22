using Business.Mailing.Abstract;
using Business.RabbitMQ.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Text;

namespace Core.RabbitMQ.Concrate
{
    public class ConsumerManager : IConsumerService
    {
        IRabbitMQService _rabbitMqService;
        IMailSender _mailSender;
        public ConsumerManager(IRabbitMQService rabbitMqService, IMailSender mailSender)
        {
            _rabbitMqService = rabbitMqService;
            _mailSender = mailSender;
        }

        public void Start(MailMessage mailMessage)
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
                        var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailMessage));
                    };

                    channel.BasicConsume(
                        queue: "Tourniquet", autoAck: true, consumer: consumer);
                }
            }

            //_mailSender.SendMail();
        }
    }
}