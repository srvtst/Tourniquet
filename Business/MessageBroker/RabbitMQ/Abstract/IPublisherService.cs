using Entities.Concrate;

namespace Business.MessageBroker.RabbitMQ.Abstract
{
    public interface IPublisherService
    {
        void Publish(Tourniquet tourniquet);
    }
}