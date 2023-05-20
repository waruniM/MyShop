using MyShopCore.Web.Api.Brokers.DateTimes;
using MyShopCore.Web.Api.Brokers.Loggings;
using MyShopCore.Web.Api.Brokers.Storages;
using MyShopCore.Web.Api.Models.Stocks;

namespace MyShopCore.Web.Api.Services.Foundations.Stocks
{
    public class StockService : IStockService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public StockService(ILoggingBroker loggingBroker, IStorageBroker storageBroker, IDateTimeBroker dateTimeBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public async ValueTask<Stock> AddStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.CurrentStock} added");

            stock.Id = Guid.NewGuid();
            stock.Created = this.dateTimeBroker.GetCurrentDateTime();
            stock.CreatedBy = Guid.NewGuid();

            return await this.storageBroker.InsertStockAsync(stock);
        }

        public async ValueTask<Stock> ModifyStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.CurrentStock} modified");

            stock.Updated = this.dateTimeBroker.GetCurrentDateTime();
            stock.UpdatedBy = Guid.NewGuid();

            return await this.storageBroker.UpdateStockAsync(stock);
        }

        public async ValueTask<Stock> RemoveStockAsync(Stock stock)
        {
            this.loggingBroker.LogInformation($"{stock.CurrentStock} removed");
            return await this.storageBroker.DeleteStockAsync(stock);
        }

        public IQueryable<Stock> RetrieveAllStocks()
        {
            return this.storageBroker.SelectAllStocks();
        }

        public async ValueTask<Stock> RetrieveStockByIdAsync(Guid stockId)
        {
            return await this.storageBroker.SelectStockByIdAsync(stockId);
        }
    }
}
