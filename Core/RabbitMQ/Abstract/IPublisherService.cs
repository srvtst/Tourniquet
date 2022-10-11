﻿using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Abstract
{
    public interface IPublisherService
    {
        void Enqueue<T>(IEnumerable<T> queueData, string queueName) where T : class, new();
    }
}