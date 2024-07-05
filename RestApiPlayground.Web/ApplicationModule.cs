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
using RestApiPlayground.Infrastructure.Repositories.Query;
using RestApiPlayground.Domain.Repositories.Query;

namespace RestApiPlayground.API
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeCommandRepository>().As<IEmployeeCommandRepository>().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeQueryRepository>().As<IEmployeeQueryRepository>().InstancePerLifetimeScope();

            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();


            #region handlers
            builder.RegisterType<GetAllEmployeesHandler>().As<IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>>().InstancePerLifetimeScope();

            builder.RegisterType<GetEmployeeByIdHandler>().As<IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<CreateEmployeeHandler>().As<IRequestHandler<CreateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<UpdateEmployeeHandler>().As<IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>>().InstancePerLifetimeScope();

            builder.RegisterType<DeleteEmployeeHandler>().As<IRequestHandler<DeleteEmployeeCommand, string>>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
