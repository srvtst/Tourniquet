using Core.RabbitMQ.Abstract;
using Entities.Concrate;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQ.Concrate
{
    //kuyruğa mesaj gönderecek yer
    public class PublisherManager : IPublisherService
    {
        IRabbitMQService _rabbitMQService;
        public PublisherManager(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        //Enqueue : sıraya almak
        //queueName : Queue kuyrukta hangi isimde tutulacağı bilgisi operasyon istek zamanı gönderilebilir.
        //queueDat : Herhangi bir tipte gönderilebilir where koşullaırına uyan
        public void Enqueue<T>(IEnumerable<T> queueData, string queueName) where T : class, new()
        {
            using (var connection = _rabbitMQService.GetConnection())
            using (var channel = connection.CreateModel())
            {
                //durable: ile in memory mi yoksa fiziksel olarak mı saklanacağı belirlenir.
                //exclusive: Yalnızca bir bağlantı tarafından kullanılır ve bu bağlantı kapandığında sıra silinir — özel olarak işaretlenirse silinmez
                //autoDelete: En son bir abonelik iptal edildiğinde en az bir müşteriye sahip olan kuyruk silinir
                //arguments: İsteğe bağlı; eklentiler tarafından kullanılır ve TTL mesajı, kuyruk uzunluğu sınırı, vb. özellikler tanımlanır.
                //QueueDeclare : Oluşturulacak olan queue' nin ismi tanımlanır.
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                //İlgili doldurulan “Tourniquet” sınıfı JsonConvert ile Serialize edilir ve byte[] dizisine çevrilip “body“‘e atanır.
                //RabbitMQ veri byte[] olarak tutulur.
                //BasicPublish() methodundaki routingKey : Girilen key’e göre ilgili queue’ye gidilmesi sağlanır. 
                //body: Queue’ye gönderilecek mesaj byte[] tipinde gönderilir.
                foreach (var queue in queueData)
                {
                    string message = JsonConvert.SerializeObject(queue);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "Tourniquet",
                                         body: body,
                                         basicProperties: null);
                }
            }
        }
    }
}