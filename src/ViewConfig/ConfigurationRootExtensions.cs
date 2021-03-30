using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewConfig
{
    public static class ConfigurationRootExtensions
    {
        public static string GetViewConfig(this IConfigurationRoot root)
        {
            List<ConfigModel> configs = new List<ConfigModel>();

            var builder = new StringBuilder();

            RecurseChildren(root, configs, builder, root.GetChildren(), "");

            return System.Text.Json.JsonSerializer.Serialize(configs);
        }

        private static void RecurseChildren(IConfigurationRoot root, List<ConfigModel> configs, StringBuilder stringBuilder, IEnumerable<IConfigurationSection> children, string indent)
        {  
            foreach (IConfigurationSection child in children)
            {
                (string Value, IConfigurationProvider Provider) valueAndProvider = GetValueAndProvider(root, child.Path);

                if (valueAndProvider.Provider != null)
                {
                    configs.Add(new ConfigModel {
                    
                         Key = child.Path,
                         Value = child.Value,
                         Provider = valueAndProvider.Provider.ToString()

                    });

                    stringBuilder
                        .Append(indent)
                        .Append(child.Key)
                        .Append('=')
                        .Append(valueAndProvider.Value)
                        .Append(" (")
                        .Append(valueAndProvider.Provider)
                        .AppendLine(")");
                }
                else
                {
                    stringBuilder
                        .Append(indent)
                        .Append(child.Key)
                        .AppendLine(":");
                }

                RecurseChildren(root, configs, stringBuilder, child.GetChildren(), indent + "  ");
            }
        }


        private static (string Value, IConfigurationProvider Provider) GetValueAndProvider(IConfigurationRoot root, string key)
        {
            foreach (IConfigurationProvider provider in root.Providers.Reverse())
            {
                if (provider.TryGet(key, out string value))
                {
                    return (value, provider);
                }
            }

            return (null, null);
        }
    }
}
