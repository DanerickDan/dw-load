using LoadDWBigData.Data.Context;
using LoadDWBigData.Data.Interfaces;
using LoadDWBigData.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace LoadDW.WorkerServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContextPool<NorthwindContext>(opt =>
                    opt.UseSqlServer(hostContext.Configuration.GetConnectionString("DbNorthWindConnection")));

                services.AddDbContextPool<DbSalesContext>(opt =>
                opt.UseSqlServer(hostContext.Configuration.GetConnectionString("DbSalesConnection")));

                services.AddScoped<ILoadDwService, LoadDwService>();

                services.AddHostedService<Worker>();
            });
    }
}