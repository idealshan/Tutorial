using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tutorial.Web.Model;
using Tutorial.Web.Services;

namespace Tutorial.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();   //注册mvc中间件服务
            services.AddSingleton<IWelcomeService, WelcomeService>();
            services.AddScoped<IRepository<Student>,InMemoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            IWelcomeService welcomeService,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            //服务器路径访问，文件访问中间件；
            app.UseFileServer();


            //MVC默认带路径;
            //app.UseMvcWithDefaultRoute();
            //MVC不带路径；
            app.UseMvc(builder =>
            {
                //home / Index-> HomeController Index()
                builder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}"); 
               // builder.MapRoute();
            });





            app.Run(async (context) =>
            {
               
                var welcome = welcomeService.GetMessage();
                await context.Response.WriteAsync(welcome);
            });
        }
    }
}
