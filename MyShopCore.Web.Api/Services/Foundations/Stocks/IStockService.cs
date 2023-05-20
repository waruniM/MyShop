using MyShopCore.Web.Api.Models.Stocks;

namespace MyShopCore.Web.Api.Services.Foundations.Stocks
{
    public interface IStockService
    {
        ValueTask<Stock> AddStockAsync(Stock stock);
        IQueryable<Stock> RetrieveAllStocks();
        ValueTask<Stock> RetrieveStockByIdAsync(Guid stockId);
        ValueTask<Stock> ModifyStockAsync(Stock stock);
        ValueTask<Stock> RemoveStockAsync(Stock stock);
    }
}
