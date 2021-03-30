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
        private readonly ViewConfigOptions _options;

        public ViewConfigMiddleware(RequestDelegate next, IConfiguration config, ViewConfigOptions options)
        {
            _next = next;
            _config = config;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.HasValue)
            {
                var path = context.Request.Path.Value.ToLowerInvariant();     

                if (path == _options.Endpoint.ToLowerInvariant())
                {
                    _options.Render = string.IsNullOrEmpty(_options.Render) ? "page" : _options.Render;

                    if (_options.Render == "page")
                    {
                        // Go to index  
                        await EmbeddedFilesHandle.IncludeEmbeddedFile(context, "/ViewConfigStaticFiles/index.html");
                        return;
                    }

                    if (_options.Render == "json")
                    {
                        context.Response.ContentType = "application/json;charset=utf-8";

                        var configData = (_config as IConfigurationRoot).GetViewConfig();
                        await context.Response.WriteAsync(configData.json);
                        return; 
                    }

                    if (_options.Render == "text")
                    { 
                        var configData = (_config as IConfigurationRoot).GetViewConfig();
                        await context.Response.WriteAsync(configData.text);
                        return;
                    }

                }

                if (path.ToLowerInvariant() == "/guid30b0a20013760892e4eb5e93c60421ec")
                {
                    var configData = (_config as IConfigurationRoot).GetViewConfig();
                    await context.Response.WriteAsync(configData.json);
                    return;
                }  
            }  

            await _next(context);
        } 
    }
}
