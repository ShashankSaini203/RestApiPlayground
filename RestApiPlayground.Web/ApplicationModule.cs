using Autofac;
using RestApiPlayground.Domain.Repositories;
using RestApiPlayground.Infrastructure.Repositories;
using RestApiPlayground.Application.Services;
using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Infrastructure.Data;

namespace RestApiPlayground.API
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();

            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
