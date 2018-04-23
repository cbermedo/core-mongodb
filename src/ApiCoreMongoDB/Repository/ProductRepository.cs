using ApiCoreMongoDB.Interfaces;
using ApiCoreMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreMongoDB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMDBContext _context;
        public ProductRepository(IMDBContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context
                            .Products
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Product> GetProduct(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.ProductName, name);
            return _context
                    .Products
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }


        public async Task<bool> Update(Product product)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Products
                        .ReplaceOneAsync(
                            filter: g => g.Id == product.Id,
                            replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.ProductName, name);
            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
