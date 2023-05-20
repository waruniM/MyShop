using MyShopCore.Web.Api.Models.Stocks;

namespace MyShopCore.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Stock> InsertStockAsync(Stock stock);
        IQueryable<Stock> SelectAllStocks();
        ValueTask<Stock> SelectStockByIdAsync(Guid stockId);
        ValueTask<Stock> UpdateStockAsync(Stock stock);
        ValueTask<Stock> DeleteStockAsync(Stock stock);
    }
}
