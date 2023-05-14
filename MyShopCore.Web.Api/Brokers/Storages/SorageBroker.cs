

using Microsoft.EntityFrameworkCore;

namespace MyShopCore.Web.Api.Brokers.Storages
{
    public partial class SorageBroker : DbContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public SorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            var connectionString = this.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
