using Microsoft.EntityFrameworkCore;
using MyShopCore.Web.Api.Models.Products;

namespace MyShopCore.Web.Api.Brokers.Storages
{
    public partial class SorageBroker
    {
        public DbSet<Product> products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            //throw new NotImplementedException();
            this.Entry(product).State = EntityState.Added;
            await this.SaveChangesAsync();

            //this.products.Add(product);
            //await this.SaveChangesAsync();

            return product;
        }
        public IQueryable<Product> SelectAllProducts()
        {
            //throw new NotImplementedException();
            return this.products.AsQueryable();
        }
        public async ValueTask<Product> SelectProductByIdAsync(Guid productId)
        {
            //throw new NotImplementedException();
            return await this.products.FindAsync(productId);
        }
        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            //throw new NotImplementedException();
            this.Entry(product).State = EntityState.Modified;
            await this.SaveChangesAsync();

            return product;
        }
        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
            //throw new NotImplementedException();
            this.Entry(product).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return product;
        }
    }
}
