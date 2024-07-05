using Autofac;
using MediatR;
using RestApiPlayground.Infrastructure.Data;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Application.Queries;
using RestApiPlayground.Application.Handlers.QueryHandler;
using RestApiPlayground.Application.Handlers.CommandHandler;
using RestApiPlayground.Infrastructure.Repositories.Command;
using RestApiPlayground.Domain.Repositories.Command;

namespace RestApiPlayground.API
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeCommandRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.RegisterType<GetAllEmployeesHandler>().As<IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>>().InstancePerLifetimeScope();

            builder.RegisterType<GetEmployeeByIdHandler>().As<IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<CreateEmployeeHandler>().As<IRequestHandler<CreateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<UpdateEmployeeHandler>().As<IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<DeleteEmployeeHandler>().As<IRequestHandler<DeleteEmployeeCommand, string>>().InstancePerLifetimeScope();
        }
    }
}
