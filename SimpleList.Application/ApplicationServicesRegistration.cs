using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SimpleList.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra por reflection las clases para configurar el mapping
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Fuent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>)));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)));

            return services;
        }
    }
}
