using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ManualHelp.Common.Extension
{
    public static class Extensions
    {
        public static string Underscore(this string value)
            => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }

        public static IMvcCoreBuilder AddCustomMvc(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                //var configuration = serviceProvider.GetService<IConfiguration>();
                //services.Configure<AppOptions>(configuration.GetSection("app"));
            }

            //services.AddSingleton<IServiceId, ServiceId>();
            services.AddTransient<IStartupInitializer, StartupInitializer>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return null;// services
                //.AddMvc()
                //.AddJsonFormatters()
                //.AddDataAnnotations()
                //.AddApiExplorer()
                //.AddDefaultJsonOptions()
                //.AddAuthorization();
        }

    }
}
