using System;

using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ManualHelp.Common;
using ManualHelp.Common.Database.MsSqlDatabase.Abstract;
using ManualHelp.Common.Database.MsSqlDatabase.Implementation;
using ManualHelp.Common.RabbitMq.Extension;
using ManualHelp.Services.Friends.Database;
using ManualHelp.Services.Friends.Domain;
using ManualHelp.Services.Friends.Messages.Commands.Friends;
using ManualHelp.Services.Friends.Repository.Abstract;
using ManualHelp.Services.Friends.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManualHelp.Service.Friend
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
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FriendsServiceDatabase>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();

            services.AddTransient<IUsersFriendsRepository, UsersFriendsRepository>();
            services.AddTransient<IMsSqlDbRepository<UsersFriends, FriendsServiceDatabase>,
                                    MsSqlDbRepository<UsersFriends, FriendsServiceDatabase>>();
            //services.AddScoped<IInitializer>();
            //services.AddTransient<IStartupInitializer, StartupInitializer>();

            builder.AddRabbitMq();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime)//, IStartupInitializer initialazer)
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

           // initialazer.InitializeAsync();
            app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<AddFriend>();

            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
