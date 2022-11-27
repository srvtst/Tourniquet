using RabbitMQ.Client;

namespace Business.MessageBroker.RabbitMQ.Abstract
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}