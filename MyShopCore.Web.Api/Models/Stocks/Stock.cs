namespace MyShopCore.Web.Api.Models.Stocks
{
    public class Stock : Audit
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int CurrentStock { get; set; }
    }
}
