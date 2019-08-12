using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BattleTechCanonWarships
{
    public static class SiteStatics
    {
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();
        private static IConfiguration mConfiguration;
        public static IConfiguration Configuration
        {
            get
            {
                if(mConfiguration == null)
                {
                    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddJsonFile("appsettings.json");
                    IConfiguration TempConfiguration = configurationBuilder.Build();
                    IConfigurationSection IncludeFiles = TempConfiguration.GetSection("IncludeFiles");
                    List<string> Includes = IncludeFiles.Get<List<string>>();
                    foreach (string s in Includes)
                    {
                        configurationBuilder.AddJsonFile(s);
                    }

                    mConfiguration = configurationBuilder.Build();

                }

                return mConfiguration;
            }
        }
    }
}
