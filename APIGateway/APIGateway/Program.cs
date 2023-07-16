using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseKestrel(options =>
                    {
                        if(args.Length > 2)
                        {
                            options.ListenAnyIP(443, listenOptions =>
                            {
                                listenOptions.UseHttps(args[1], args[2]); // cert and password for Https
                            });
                        }
                        else
                        {
                            options.ListenAnyIP(80); // Http
                        }
                    });
                })
            .ConfigureLogging(logging => logging.AddConsole())
            .ConfigureAppConfiguration(config => config.AddJsonFile("ocelot.json"));
    }
}
