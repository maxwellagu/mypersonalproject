using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MyBooks
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				var configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.Build();
				Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();

				//logging using serial logging
				/*Log.Logger = new LoggerConfiguration()
				.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();*/

				CreateHostBuilder(args).Build().Run();
			}
			finally
			{
				Log.CloseAndFlush();
			}

		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.UseSerilog()
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
