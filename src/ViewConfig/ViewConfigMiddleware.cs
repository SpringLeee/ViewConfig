using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewConfig
{
    internal class ViewConfigMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public ViewConfigMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.HasValue)
            {
                var path = context.Request.Path.Value;   

                if (path.ToLowerInvariant() == "/ViewConfig".ToLowerInvariant())
                {
                    // Go to index  
                    await EmbeddedFilesHandle.IncludeEmbeddedFile(context,"/ViewConfigStaticFiles/index.html");
                    return;     
                }

                if (path.Contains("/ViewConfigStaticFiles".ToLowerInvariant()))
                {
                    await EmbeddedFilesHandle.IncludeEmbeddedFile(context,path);
                    return;
                }

                if (path.ToLowerInvariant() == "/guid30b0a20013760892e4eb5e93c60421ec")
                {
                    var configString = (_config as IConfigurationRoot)?.GetViewConfig();
                    await context.Response.WriteAsync(configString);
                    return;
                }  
            }  

            await _next(context);
        } 
    }
}
