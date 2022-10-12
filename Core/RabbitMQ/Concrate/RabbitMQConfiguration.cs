using Core.RabbitMQ.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    public class RabbitMQConfiguration : IRabbitMQConfiguration
    {
        IConfiguration _configuration { get; }
        public RabbitMQConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string HostName => _configuration.GetSection("RabbitMQConfiguration : HostName").Value;

        public string UserName => _configuration.GetSection("RabbitMQConfiguration:UserName").Value;

        public string Password => _configuration.GetSection("RabbitMQConfiguration:Password").Value;

        public int Port => Convert.ToInt32(_configuration.GetSection("RabbitMQConfiguration : Port").Value);
    }
}