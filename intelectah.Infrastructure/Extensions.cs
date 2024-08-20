using intelectah.Domain.Repositories;
using intelectah.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace intelectah.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
