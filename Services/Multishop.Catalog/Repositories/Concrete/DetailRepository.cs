﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class DetailRepository : IDetailRepository
    {
        private readonly IMongoCollection<Detail> detailCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public DetailRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            detailCollection = db.GetCollection<Detail>(this.mongodbDatabaseOptions.DetailCollection);
        }

        public async Task AddAsync(Detail entity) =>
            await detailCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await detailCollection.DeleteOneAsync(detail => detail.Id == entityId);

        public async Task UpdateAsync(Detail entity) =>
            await detailCollection.FindOneAndReplaceAsync(detail => detail.Id == entity.Id, entity);

        public async Task<Detail> GetFirstOrDefaultAsync(Expression<Func<Detail, bool>> expression) =>
            await detailCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Detail>> GetAllAsync() =>
            await detailCollection.Find(detail => true).ToListAsync();
    }
}