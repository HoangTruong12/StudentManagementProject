using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Data;
using Web.Service.Implement;
using Web.Service.Interfaces;

namespace Web
{
    public static class DependencyRegistration
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ClassService>().As<IClassService>().InstancePerLifetimeScope();

            var connectionString = ConfigurationManager.ConnectionStrings["StudentManagementEntities"].ConnectionString;
            builder.Register<IStudentManagementEntities>(c => new StudentManagementEntities(connectionString)).InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}