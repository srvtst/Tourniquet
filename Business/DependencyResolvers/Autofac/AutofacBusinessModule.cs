using Autofac;
using Business.Abstract;
using Business.Concrate;
using Core.Mailing.Abstract;
using Core.Mailing.Concrate;
using Core.RabbitMQ.Abstract;
using Core.RabbitMQ.Concrate;
using Core.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Inversion of Control (IoC) --> Dependency Injection (DI)
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();
            builder.RegisterType<TourniquetManager>().As<ITourniquetService>().SingleInstance();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();
            builder.RegisterType<EfTourniquetDal>().As<ITourniquetDal>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<RabbitMQManager>().As<IRabbitMQService>().SingleInstance();
            builder.RegisterType<RabbitMQConfiguration>().As<IRabbitMQConfiguration>().SingleInstance();
            builder.RegisterType<PublisherManager>().As<PublisherManager>().SingleInstance();
            builder.RegisterType<MailSenderManager>().As<IMailSender>().SingleInstance();
        }
    }
}