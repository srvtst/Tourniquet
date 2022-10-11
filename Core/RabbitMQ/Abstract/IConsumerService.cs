using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Abstract
{
    public interface IConsumerService
    {
        void Start(Tourniquet tourniquet);
    }
}