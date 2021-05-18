using System;
using System.Threading.Tasks;
using IOT_Data.dataInteractors;
using IOT_Data.interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimulatorBusiness.Business;
using SimulatorBusiness.Interfaces;

namespace SimulatorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            new LogicRunner(host.Services.CreateScope().ServiceProvider.GetRequiredService<SimExecuter>())
                .Runtime();

            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IDataBaseFlusher, DataBaseFlusher>()
                            .AddScoped<IDataInserter, DataInserter>()
                            .AddScoped<IDataPurger, DataPurger>()
                            .AddScoped<IInfoGetter, InfoGetter>()
                            .AddSingleton<SimExecuter>()
                );
    }
}
