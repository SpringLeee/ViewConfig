using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewConfig
{
    public class ViewConfigOptions : IOptions<ViewConfigOptions>
    {
        internal string Endpoint { get; set; }

        internal string Render { get; set; }

        public ViewConfigOptions Value => this;
    } 

}
