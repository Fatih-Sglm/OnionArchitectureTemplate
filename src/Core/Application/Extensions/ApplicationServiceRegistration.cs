using Application.Abstractions.Rules;
using Application.Commons.Pipelines.Authorization;
using Application.Commons.Pipelines.Caching;
using Application.Commons.Pipelines.Logging;
using Application.Commons.Pipelines.Transaction;
using Application.Commons.Pipelines.Validation;
using CrossCuttingConcerns.Logging.Serilog;
using CrossCuttingConcerns.Logging.Serilog.Logger;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ApplicationServiceRegistration
    {

        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<LoggerServiceBase, FileLogger>();
            AddPipeLineExtensions(services);
            AddSubClassesOfType(services, Assembly.GetExecutingAssembly());
            AddDIExtension(services, Assembly.GetExecutingAssembly());
            AddService(services);
        }


        private static void AddService(IServiceCollection services)
        {


        }
        private static void AddDIExtension(IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
        }
        private static void AddPipeLineExtensions(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehavior<,>));
        }

        private static void AddSubClassesOfType(IServiceCollection services, Assembly assembly, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var type = typeof(BaseBusinessRules);
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
        }
    }
}
