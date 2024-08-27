using FluentValidation.AspNetCore;
using intelectah.MVC.Validators.Create;

namespace intelectah.MVC
{
    public static class Extensions
    {
        public static IServiceCollection AddMVC(this IServiceCollection services)
        {
            services.AddValidators();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddControllersWithViews()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUsuarioValidator>());

            return services;
        }
    }
}
