using Autofac;
using RestApiPlayground.Domain.Interfaces;
using RestApiPlayground.Infrastructure.Repositories;
using RestApiPlayground.Service.Services;

namespace RestApiPlayground
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();
        }
    }
}
