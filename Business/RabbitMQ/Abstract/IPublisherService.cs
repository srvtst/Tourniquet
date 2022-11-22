using Entities.Concrate;

namespace Business.RabbitMQ.Abstract
{
    public interface IPublisherService
    {
        void Enqueue(Tourniquet tourniquet);
    }
}