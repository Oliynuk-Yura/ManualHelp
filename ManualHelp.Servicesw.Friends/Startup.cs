using Autofac;
using ManualHelp.Services.Friends.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using System;
using ManualHelp.Services.Friends.Repository.Implementation;
using ManualHelp.Services.Friends.Repository.Abstract;
using ManualHelp.Common.Database.MsSqlDatabase.Implementation;
using ManualHelp.Services.Friends.Domain;
using ManualHelp.Common.Database.MsSqlDatabase.Abstract;
using ManualHelp.Common;
using ManualHelp.Common.RabbitMq.Extension;
using ManualHelp.Services.Friends.Messages.Commands.Friends;
using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Services.Friends.Handler.Friends;

namespace ManualHelp.Servicesw.Friends
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

            services.AddDbContext<FriendsServiceDatabase>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces();
            builder.Populate(services);
           

           // services.AddTransient<IUsersFriendsRepository, UsersFriendsRepository>();
           // services.AddTransient<IMsSqlDbRepository<UsersFriends, FriendsServiceDatabase>,
            //                        MsSqlDbRepository<UsersFriends, FriendsServiceDatabase>>();
            //services.AddTransient<IStartupInitializer, StartupInitializer>();
            builder.RegisterType<StartupInitializer>().As<IStartupInitializer>()
                .InstancePerDependency();
                        
            builder.RegisterType<UsersFriendsRepository>().As<IUsersFriendsRepository>()
                .InstancePerDependency();

            builder.RegisterType<MsSqlDbRepository<UsersFriends, FriendsServiceDatabase>>()
                .As<IMsSqlDbRepository<UsersFriends, FriendsServiceDatabase>>()
                .InstancePerLifetimeScope();

            builder.AddRabbitMq();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IStartupInitializer initialazer)
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
            initialazer.InitializeAsync();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<AddFriend>();

            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
