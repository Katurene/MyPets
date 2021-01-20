using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPets.Service;

namespace MyPets
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
       
        public void ConfigureServices(IServiceCollection services)
        {
            //подкл конфиг из appsettings.json("Project"=стр. 2) и new Config()-класс
            Configuration.Bind("Project", new Config());
            //добавляем поддержку контролл-в и предст-й mvc
            services.AddControllersWithViews()
                //совместимость с asp.net.core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//исп стр исключений для разработчика
            }

            app.UseRouting();//маршрутизация

            app.UseStaticFiles();//подкл статич файлов

            //регистрация маршрутов
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
