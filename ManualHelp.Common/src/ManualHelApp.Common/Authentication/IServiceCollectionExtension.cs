using System;
using System.Text;
using ManualHelp.Common.Authentication.JwtIdentity;
using ManualHelp.Common.Authentication.JwtIdentity.Middleware;
using ManualHelp.Common.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ManualHelp.Common.Authentication
{
    public static class IServiceCollectionExtension
    {
        private static readonly string _sectionName = "jwt";

        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var section = configuration.GetSection(_sectionName);
            var options = configuration.GetOptions<JwtOptions>(_sectionName);
            //services.Configure<JwtOptions>(section);
            services.AddSingleton(options);
            services.AddTransient<AccessTokenValidatorMiddleware>();

            var key = Encoding.UTF8.GetBytes(options.SecretKey);
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = options.ValidateIssuer,
                    ValidIssuer = options.Issuer,
                    ValidAudience = options.ValidAudience,
                    ValidateLifetime = options.ValidateLifetime,
                    ValidateAudience = options.ValidateAudience,
                    ClockSkew = TimeSpan.Zero,
                    ValidateActor = options.ValidateActor

                };               
            });
        }

        public static IApplicationBuilder UseAccessTokenValidator
            (this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccessTokenValidatorMiddleware>();
        }
    }
}
