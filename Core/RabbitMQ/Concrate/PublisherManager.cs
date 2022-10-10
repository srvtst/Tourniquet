using Core.RabbitMQ.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    public class PublisherManager : IPublisherService
    {
        //kuyruğa mesaj gönderecek yer
        IRabbitMQService _rabbitMQService;
        public PublisherManager(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }


    }
}