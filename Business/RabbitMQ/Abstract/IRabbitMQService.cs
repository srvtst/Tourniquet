using RabbitMQ.Client;

namespace Business.RabbitMQ.Abstract
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}