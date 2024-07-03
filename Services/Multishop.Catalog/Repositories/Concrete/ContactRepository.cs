﻿using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ContactRepository : IContactRepository
    {
        private readonly IMongoCollection<Contact> contactCollection;
        public ContactRepository(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            contactCollection = db.GetCollection<Contact>(dbSettings.ContactCollectionName);
        }

        public async Task AddAsync(Contact entity)
        {
            entity.SendDate = DateTime.Now;
            await contactCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await contactCollection.DeleteOneAsync(contact => contact.Id == entityId);
        }

        public async Task UpdateAsync(Contact entity)
        {
            await contactCollection.FindOneAndReplaceAsync(contact => contact.Id == entity.Id, entity);
        }

        public async Task<Contact> GetFirstOrDefaultAsync(Expression<Func<Contact, bool>> expression)
        {
            return await contactCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression)
        {
            return await contactCollection.Find(expression).ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await contactCollection.Find(contact => true).ToListAsync();
        }
    }
}