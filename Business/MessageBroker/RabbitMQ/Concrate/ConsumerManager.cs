using Business.Mailing.Abstract;
using Business.MessageBroker.RabbitMQ.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Business.MessageBroker.RabbitMQ.Concrate
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

        public void Start()
        {
            using var connection = _rabbitMqService.GetConnection();

            using var channel = _rabbitMqService.GetModel(connection);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("Tourniquet", false, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                channel.BasicAck(e.DeliveryTag, false);
            };

            _mailSender.SendMail("servet.soysal@hotmail.com", "Consumer başarılı olarak okuma yaptı.");
        }
    }
}