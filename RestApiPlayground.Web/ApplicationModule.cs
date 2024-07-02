using Autofac;
using MediatR;
using RestApiPlayground.Domain.Repositories;
using RestApiPlayground.Infrastructure.Repositories;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Services;
using RestApiPlayground.Application.Handlers.QueryHandler;
using RestApiPlayground.Application.Handlers.CommandHandler;

namespace RestApiPlayground.API
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();

            builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();

            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.RegisterType<CreateEmployeeHandler>().As<IRequestHandler<CreateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<GetAllEmployeesHandler>().As<IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>>().InstancePerLifetimeScope();

            builder.RegisterType<GetEmployeeByIdHandler>().As<IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<UpdateEmployeeHandler>().As<IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();
        }
    }
}
