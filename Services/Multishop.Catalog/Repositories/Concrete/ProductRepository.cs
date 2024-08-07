﻿using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        public ProductRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            productCollection = db.GetCollection<Product>(mongodbDatabaseOptions.ProductCollectionName);
        }

        public async Task AddAsync(Product entity)
        {
            await productCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await productCollection.DeleteOneAsync(product => product.Id == entityId);
        }

        public async Task UpdateAsync(Product entity)
        {
            await productCollection.FindOneAndReplaceAsync(product => product.Id == entity.Id, entity);
        }

        public async Task<Product> GetFirstOrDefaultAsync(Expression<Func<Product, bool>> expression)
        {
            return await productCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWhereAsync(Expression<Func<Product, bool>> expression)
        {
            return await productCollection.Find(expression).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await productCollection.Find(product => true).ToListAsync();
        }
    }
}