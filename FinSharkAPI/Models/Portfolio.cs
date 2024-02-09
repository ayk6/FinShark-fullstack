using System.ComponentModel.DataAnnotations.Schema;

namespace FinSharkAPI.Models
{
	[Table("Portfolios")]
	public class Portfolio
	{
		public int UserId { get; set; }
        public int StockId { get; set; }
        public User User { get; set; }
        public Stock Stock { get; set; }


    }
}
