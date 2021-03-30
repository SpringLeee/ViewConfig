using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.WebAPI", Version = "v1" }); 
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                // 自定义端点
                app.UseViewConfig(x => x.Map("/Info")); 

                // 页面格式
                app.UseViewConfig(x => x.RenderPage()); 

                // Json格式
                app.UseViewConfig(x => x.Map().RenderJson()); 

                // 文本格式
                app.UseViewConfig(x => x.Map("/Info").RenderText());   

            } 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
           
        }
    }
}
