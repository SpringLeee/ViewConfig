using System;
using System.Collections.Generic;
using System.Text;
using ViewConfig;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ViewConfigOptionsExtensions
    {
        public static ViewConfigOptions Map(this ViewConfigOptions options,string endpoint = "/viewconfig")
        {
            options.Endpoint = endpoint;

            return options; 
        }

        public static ViewConfigOptions RenderPage(this ViewConfigOptions options)
        {
            options.Render = "page";
            return options;
        }

        public static ViewConfigOptions RenderText(this ViewConfigOptions options)
        {
            options.Render = "text";
            return options;
        }

        public static ViewConfigOptions RenderJson(this ViewConfigOptions options)
        {
            options.Render = "json";
            return options;
        } 

    }
}
