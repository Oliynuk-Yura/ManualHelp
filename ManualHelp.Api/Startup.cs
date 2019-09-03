using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ManualHelp.Common;
using ManualHelp.Common.Authentication;
using ManualHelp.Common.Dispatchers;
using ManualHelp.Common.Extension;
using ManualHelp.Common.RabbitMq.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManualHelp.Api
{
    public class Startup
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddMvc();
            services.AddAuthorization();
            //services.AddSwaggerDocs();
            //services.AddConsul();
            services.AddJwt();
            //services.AddJaeger();
            //services.AddOpenTracing();
            //services.AddRedis();
            //services.AddInitializers(typeof(IMongoDbInitializer));

            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithExposedHeaders(Headers));
            });

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();

            builder.RegisterType<StartupInitializer>().As<IStartupInitializer>()
               .InstancePerDependency();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
             IApplicationLifetime applicationLifetime, 
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();

            app.UseRabbitMq();
            
            applicationLifetime.ApplicationStopped.Register(() =>
            {               
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
