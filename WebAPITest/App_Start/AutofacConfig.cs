using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WebAPITest.Repositorys;
using WebAPITest.Services;

namespace WebAPITest.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            Register(builder);

            Container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void Register(ContainerBuilder builder)
        {
            var assembly = typeof(AutofacConfig).Assembly;
            builder.RegisterApiControllers(assembly);


            //Service
            builder.RegisterType<SupplierApiProfileService>().As<ISupplierApiProfileService>().InstancePerDependency();
            builder.RegisterType<TestService>().As<ITestService>().InstancePerDependency();

            //Repository
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>().InstancePerDependency(); //PerDependency
            //builder.RegisterType<MockDBContext>().SingleInstance();
            builder.RegisterType<MockDBContext>().InstancePerLifetimeScope();


            builder.RegisterType<ValidateTokenHandler>().As<DelegatingHandler>();
            builder.RegisterType<TestHandler>().As<DelegatingHandler>();
        }
    }
}