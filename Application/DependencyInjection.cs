using System.Reflection;
using Application.Infrastructure.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Features.Users;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddAutoMapper(typeof(UserMapperProfile));
    }
}