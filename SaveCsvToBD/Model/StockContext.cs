using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SaveCsvToBD.Model
{
	public class StockContext : DbContext
	{
		private readonly IConfiguration _config;

		public StockContext(DbContextOptions<StockContext> options, IConfiguration config) : base(options)
		{
			this._config = config;
		}

		public DbSet<StockRecord> StockRecord { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString"));
		}
	}
}