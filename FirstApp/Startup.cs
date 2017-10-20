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

        //Alt katmanlardan gelen servis katmanlarımızı burada tanımlıyoruz. Yani DI burada gerçekleşecek.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();//Olurda biri senden IProductService isterse git ona arkada Product Manager newle ve onu ver.

            services.AddScoped<IProductDal, EfProductDal>();
            
           // services.AddSingleton<IProductService, ProductManager>();//Bir kere instanse oluşturulur. Herkes o instance kullanır.
                                                                     //A kullanıcı bir istekte bulunduğunda bir kere instance alınır 
                                                                     //b kullanıcı da instance istediği zaman a kullanıcısının instance kullanılır.

              


          //  services.AddScoped<>(); Her action için bir tane instance üretir.

            services.AddMvc(); 


        }

        //Midleware yapılandırması gerçekleştirdiğimiz yer.
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

            app.UseStaticFiles();                                                            
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
