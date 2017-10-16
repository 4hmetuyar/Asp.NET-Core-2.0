using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Apstract;
using Abc.Northwind.Business.Concreate;
using Abc.Northwind.DataAccess.Apstract;
using Abc.Northwind.DataAccess.Concreate.EntityFramework;
using Abc.Northwind.WebUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Alt katmanlardan gelen servis katmanlar�m�z� burada tan�ml�yoruz. Yani DI burada ger�ekle�ecek.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();//Olurda biri senden IProductService isterse git ona arkada Product Manager newle ve onu ver.

            services.AddScoped<IProductDal, EfProductDal>();
            
            services.AddSingleton<IProductService, ProductManager>();//Bir kere instanse olu�turulur. Herkes o instance kullan�r.
                                                                     //A kullan�c� bir istekte bulundu�unda bir kere instance al�n�r b kullan�c� da instance istedi�i zaman a kullan�c�s�n�n instance kullan�l�r.


          //  services.AddScoped<>(); Her action i�in bir tane instance �retir.

            services.AddMvc(); 


        }

        //Midleware yap�land�rmas� ger�ekle�tirdi�imiz yer.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(); //sabit mod�lleri wwwroot i�inde alyans vermek i�in kulland�k.
            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
