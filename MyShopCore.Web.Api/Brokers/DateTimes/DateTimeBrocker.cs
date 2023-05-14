namespace MyShopCore.Web.Api.Brokers.DateTimes
{
    public class DateTimeBrocker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() => DateTime.UtcNow;
        //{
        //    throw new NotImplementedException();
        //}
    }
}
