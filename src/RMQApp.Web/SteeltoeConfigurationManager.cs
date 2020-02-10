using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace RMQApp.Web
{
    public sealed class SteeltoeConfigurationManager
    {
        static SteeltoeConfigurationManager instance = null;
        static readonly object @lock = new object();

        readonly IConfiguration _configuration;

        SteeltoeConfigurationManager()
        {
            _configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json")
                //.AddXmlFile()
                .AddEnvironmentVariables() // bootstrap config-server
                .AddCloudFoundry()
                //.AddConfigServer()
                .AddEnvironmentVariables() // override config-server
                .Build();
        }

        ~SteeltoeConfigurationManager()
        {
        }

        public IConfiguration GetConfiguration()
        {
            return _configuration;
        }

        public static SteeltoeConfigurationManager Instance
        {
            get
            {
                lock (@lock)
                {
                    if (instance == null)
                    {
                        instance = new SteeltoeConfigurationManager();
                    }

                    return instance;
                }
            }
        }
    }
}
