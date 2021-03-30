using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using ViewConfig;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IApplicationBuilder UseViewConfig(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ViewConfigMiddleware>();
        }
    }
}
