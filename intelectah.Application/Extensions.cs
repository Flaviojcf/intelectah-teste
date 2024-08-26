using intelectah.Application.Services;
using intelectah.Application.Services.Interfaces;
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
            services.AddScoped<IValidateFabricanteRulesService, ValidateFabricanteRulesService>();

            return services;
        }
    }
}
