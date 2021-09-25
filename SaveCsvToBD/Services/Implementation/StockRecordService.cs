using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SaveCsvToBD.Services.Interface;

namespace SaveCsvToBD.Services.Implementation
{
	public class StockRecordService : IStockRecordService
	{
		private readonly ILogger<StockRecordService> _logger;
		private readonly IConfiguration _config;

		public StockRecordService(ILogger<StockRecordService> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}

		public void Run()
		{
			_logger.LogInformation("Url to download {url}", _config.GetValue<string>("fileUrl"));
		}
	}
}
