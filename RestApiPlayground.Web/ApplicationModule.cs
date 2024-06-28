﻿using Autofac;
using RestApiPlayground.Domain.Repositories;
using RestApiPlayground.Infrastructure.Repositories;
using RestApiPlayground.Application.Services;
using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
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

            builder.RegisterType<CreateEmployeeHandler>().AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

        }
    }
}
