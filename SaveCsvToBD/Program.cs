using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaveCsvToBD.Services.Implementation;
using SaveCsvToBD.Services.Interface;
using Serilog;

namespace SaveCsvToBD
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			var host = BuildConfig(builder);

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Build())
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateLogger();

			Log.Logger.Information("Starting Console App");

			// Service
			var stockRecordService = ActivatorUtilities.CreateInstance<StockRecordService>(host.Services);
			stockRecordService.Run();
		}

		static IHost BuildConfig(IConfigurationBuilder builder)
		{
			builder.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile(
					$"appsettings.json.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Development"}.json",
					optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddTransient<IStockRecordService, StockRecordService>();
				})
				.UseSerilog()
				.Build();
		}
	}
}
