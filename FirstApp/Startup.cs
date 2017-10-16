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

        //Alt katmanlardan gelen servis katmanlarýmýzý burada tanýmlýyoruz. Yani DI burada gerçekleþecek.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();//Olurda biri senden IProductService isterse git ona arkada Product Manager newle ve onu ver.

            services.AddScoped<IProductDal, EfProductDal>();
            
            services.AddSingleton<IProductService, ProductManager>();//Bir kere instanse oluþturulur. Herkes o instance kullanýr.
                                                                     //A kullanýcý bir istekte bulunduðunda bir kere instance alýnýr b kullanýcý da instance istediði zaman a kullanýcýsýnýn instance kullanýlýr.


          //  services.AddScoped<>(); Her action için bir tane instance üretir.

            services.AddMvc(); 


        }

        //Midleware yapýlandýrmasý gerçekleþtirdiðimiz yer.
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

            app.UseStaticFiles(); //sabit modülleri wwwroot içinde alyans vermek için kullandýk.
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
