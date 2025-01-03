using Fidelicard.Usuario.Core.Interface;
using Fidelicard.Usuario.Core.Service;
using Fidelicard.Usuario.Infra.Config;
using Fidelicard.Usuario.Infra.EntityMapping.AutoMapper;
using Fidelicard.Usuario.Infra.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Fidelicard.Usuario.Configs
{
    public static class InjectionConfig
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {   
            ConfigureHttpClient(services, builder.Configuration);
                        
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddProfile(new AutoMapperProfile());
            }, typeof(AutoMapperProfile).Assembly);

            return services;
        }

        private static void ConfigureHttpClient(IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var config = configuration.GetSection("WebAPI.Services.Communication");
        }       
    }
}