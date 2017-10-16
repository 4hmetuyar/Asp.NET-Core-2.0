using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Abc.Northwind.WebUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var option = new StaticFileOptions();
            option.RequestPath = "/node_modules"; //Sana bu adresden bir request gelirse onu yukarıda verdiğim roota yönlendir.
            option.FileProvider = provider;

            app.UseStaticFiles(option);
            return app;
        }
    }
}
