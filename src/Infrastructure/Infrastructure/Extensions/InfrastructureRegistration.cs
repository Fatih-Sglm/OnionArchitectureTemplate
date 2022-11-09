using Application.Abstractions.Token;
using Infrastructure.Concrete.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            AddService(services);
        }
        private static void AddService(IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
