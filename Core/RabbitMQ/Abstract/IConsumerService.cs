using System.Net.Mail;

namespace Core.RabbitMQ.Abstract
{
    public interface IConsumerService
    {
        void Start(MailMessage mailMessage);
    }
}