using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ManualHelp.Common;
using ManualHelp.Common.RabbitMq.Extension;
using ManualHelp.Service.EventNotification.Messages.Event;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManualHelp.Service.EventNotification
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                  
            
           // services.AddInitializers(typeof(IMongoDbInitializer));
            

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);           
            builder.AddRabbitMq();

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
            app.UseRabbitMq()                
                .SubscribeEvent<FriendAdded>();

           
            applicationLifetime.ApplicationStopped.Register(() =>
            {                
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
