using FinSharkAPI.DTO.Stock;
using FinSharkAPI.Models;

namespace FinSharkAPI.Mappers
{
	public static class StockMapper
	{
		public static StockDto toStockDto(this Stock stockModel)
		{
			return new StockDto
			{
				Id = stockModel.Id,
				Symbol = stockModel.Symbol,
				CompanyName = stockModel.CompanyName,
				Purchase = stockModel.Purchase,
				LastDiv = stockModel.LastDiv,
				Industry = stockModel.Industry,
				MarketCap = stockModel.MarketCap,
				//Comments = stockModel.Comments.Select(c => c.toCommentDto()).ToList()
			};
		}

		public static Stock toStockFromCreateDto(this CreateStockDto createStockDto)
		{
			return new Stock
			{
				Symbol = createStockDto.Symbol,
				CompanyName = createStockDto.CompanyName,
				Purchase = createStockDto.Purchase,
				LastDiv = createStockDto.LastDiv,
				Industry = createStockDto.Industry,
				MarketCap= createStockDto.MarketCap,
				//Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
			};
		}

		public static Stock UpdateFromDto(this Stock stock, UpdateStockDto updateStockDto)
		{
			stock.Symbol = updateStockDto.Symbol;
			stock.CompanyName = updateStockDto.CompanyName;
			stock.Purchase = updateStockDto.Purchase;
			stock.LastDiv = updateStockDto.LastDiv;
			stock.Industry = updateStockDto.Industry;
			stock.MarketCap = updateStockDto.MarketCap;

			return stock;
		}
	}
}
