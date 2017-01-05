using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SportsStore.Models
{
    public class ProductRepository : IRepository
    {
        private ProductDbContext context = new ProductDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                var orders = context.Orders.ToList();
                //var orderLines = context.OrderLines.ToList();
                return orders;
            }
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                var dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var dbEntry = context.Products.Find(productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public async Task<int> SaveOrderAsync(Order order)
        {
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Order> DeleteOrderAsync(int orderId)
        {
            var dbEntry = context.Orders.Find(orderId);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
    }
}