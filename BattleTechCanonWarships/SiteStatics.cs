using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BattleTechCanonWarships
{
    public static class SiteStatics
    {
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();
        static private WarshipsContext mContext = null;

        static public WarshipsContext Context
        {
            get
            {
                if(mContext == null)
                {
                    DbContextOptionsBuilder<WarshipsContext> optionsBuilder = new DbContextOptionsBuilder<WarshipsContext>();
                    optionsBuilder.UseSqlServer(SiteStatics.Configuration.GetSection("ConnectionStrings")["Default"]);

                    mContext = new WarshipsContext(optionsBuilder.Options);
                }
                return mContext;
            }
        }
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
