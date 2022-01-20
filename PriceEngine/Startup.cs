using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PriceEngine.Configurations;

namespace PriceEngine
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }        

        public Startup()
        {
            //you can add different setting based environment

            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddRequestInjections()
                    .AddSingleton<IConfiguration>(Configuration)
                    .AddSingleton(services);           
        }
    }
}
