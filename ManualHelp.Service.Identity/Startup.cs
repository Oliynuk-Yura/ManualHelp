using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ManualHelp.Common;
using ManualHelp.Common.RabbitMq.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManualHelp.Service.Identity.Messages.Command.JwtIdentity;
using ManualHelp.Service.Identity.Repository.Implementation.JwtIdentity;
using ManualHelp.Service.Identity.Repository.Abstract.JwtIdentity;
using ManualHelp.Service.Identity.Domain.JwtIdentity;
using ManualHelp.Service.Identity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ManualHelp.Service.Identity
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
            services.AddMvc(options=>
                options.ReturnHttpNotAcceptable = true)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // services.AddInitializers(typeof(IMongoDbInitializer));
            //services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<IdentityServiceDatabase>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IdentityServiceDatabase>()
                .AddDefaultTokenProviders();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);

            builder.RegisterType<IdentityService>().As<IIdentityService>()
               .InstancePerDependency();
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
            app.UseAuthentication();
            app.UseRabbitMq()
                .SubscribeCommand<SignUpUser>();


            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}

