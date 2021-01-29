using biteminds.promote.data.Configurations;
using biteminds.promote.data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biteminds.promote.api.Services
{
    public class PromocionService
    {
        private readonly IMongoCollection<Promocion> _promocion;
        private readonly DeveloperPromotionConfiguration _settings;

        /// <summary>
        /// cttor
        /// </summary>
        /// <param name="settings"></param>
        public PromocionService(IOptions<DeveloperPromotionConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _promocion = database.GetCollection<Promocion>(_settings.PromocionCollectionName);
        }

        public async Task<List<Promocion>> GetAllAsync()
        {
            return await _promocion.Find(c => true).ToListAsync();
        }
        
        public async Task<Promocion> GetByIdAsync(string id)
        {
            return await _promocion.Find<Promocion>(c => c.Id == id).FirstOrDefaultAsync();
        }
        
        public async Task<Promocion> CreateAsync(Promocion customer)
        {
            await _promocion.InsertOneAsync(customer);
            return customer;
        }
        
        public async Task UpdateAsync(string id, Promocion customer)
        {
            await _promocion.ReplaceOneAsync(c => c.Id == id, customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _promocion.DeleteOneAsync(c => c.Id == id);
        }
    }
}
