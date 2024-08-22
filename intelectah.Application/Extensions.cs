using intelectah.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace intelectah.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IValidateUsuarioRulesService, ValidateUsuarioRulesService>();

            return services;
        }
    }
}
