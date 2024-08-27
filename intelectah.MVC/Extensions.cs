using DinkToPdf;
using DinkToPdf.Contracts;
using FluentValidation.AspNetCore;
using intelectah.MVC.Validators.Create;

namespace intelectah.MVC
{
    public static class Extensions
    {
        public static IServiceCollection AddMVC(this IServiceCollection services)
        {
            services.AddValidators();
            services.AddPdfConverter();
            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterUsuarioValidator>());

            return services;
        }

        private static IServiceCollection AddPdfConverter(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }
}
