using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BeckonedPath.Data.Interfaces;
using BeckonedPath.Data.Models;
using BeckonedPath.Service.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeckonedPath.Service
{
    public class Startup
    {
        public IConfiguration Configuration {get; set;}

        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder();
            Configuration = builder.AddJsonFile(@"C:\Revature\project-two\src\BeckonedPath.Service\appsettings.dev.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //db services
            services.AddDbContext<Project2Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            
            //framework services
            services.AddMvc();

            //register application services
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IEventsRepo, EventsRepo>();
            services.AddScoped<IEventCommentsRepo, EventCommentsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder();
            //Configuration = builder.AddJsonFile(@"appsettings.json").Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
            app.UseMvc();
            //    routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});


            //app.Run(async (context) =>
            //{

            //    await context.Response.WriteAsync("hello work");
            //});


        }
    }
}
