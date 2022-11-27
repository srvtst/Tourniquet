using Autofac;
using Business.Abstract;
using Business.Concrate;
using Business.Mailing.Abstract;
using Business.Mailing.Concrate;
using Business.MessageBroker.RabbitMQ.Abstract;
using Business.MessageBroker.RabbitMQ.Concrate;
using Core.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrate;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();
            builder.RegisterType<TourniquetManager>().As<ITourniquetService>().SingleInstance();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();
            builder.RegisterType<EfTourniquetDal>().As<ITourniquetDal>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<MailSenderManager>().As<IMailSender>().SingleInstance();
            builder.RegisterType<PublisherManager>().As<IPublisherService>().SingleInstance();
            builder.RegisterType<RabbitMQManager>().As<IRabbitMQService>().SingleInstance();
            builder.RegisterType<ConsumerManager>().As<IConsumerService>().SingleInstance(); 
        }
    }
}