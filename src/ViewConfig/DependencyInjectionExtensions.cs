using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using ViewConfig;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IApplicationBuilder UseViewConfig(this IApplicationBuilder app,Action<ViewConfigOptions> options = null)
        {
            ViewConfigOptions opt = new ViewConfigOptions();
             
            if (options != null) options.Invoke(opt);

            if (string.IsNullOrEmpty(opt.Endpoint)) opt.Endpoint = "/viewconfig";

            if (string.IsNullOrEmpty(opt.Render)) opt.Render = "page";

            return app.UseMiddleware<ViewConfigMiddleware>(opt);
        }
    }
}
