using System;
using System.ComponentModel.DataAnnotations;

namespace SaveCsvToBD.Model
{
	public class StockRecord
	{
		[Key]
		public int IdStockRecord { get; set; }
		public int PointOfSale { get; set; }
		public int Product { get; set; }
		public DateTime Date { get; set; }
		public int Stock { get; set; }
	}
}