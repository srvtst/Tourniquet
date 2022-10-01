using Autofac;
using Business.Abstract;
using Business.Concrate;
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
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<TourniquetManager>().As<ITourniquetService>().SingleInstance();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();
            builder.RegisterType<EfTourniquetDal>().As<ITourniquetDal>().SingleInstance();
        }
    }
}