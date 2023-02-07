using System;
using InventoryControl.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace InventoryControl.Services
{
	public class CategoryService
	{
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IOptions<InventoryControlDatabaseSettings> inventoryControlDatabaseSettings)
        {
            var mongoClient = new MongoClient(inventoryControlDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(inventoryControlDatabaseSettings.Value.DatabaseName);
            _categoryCollection = mongoDatabase.GetCollection<Category>(inventoryControlDatabaseSettings.Value.CategoryCollectionName);
        }

        public async Task<List<Category>> GetCategoryAsync() =>
            await _categoryCollection.Find(_ => true).ToListAsync();


        public async Task<Category?> GetCategoryAsync(string id) =>
            await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateCategoryAsync(Category newCategory) =>
            await _categoryCollection.InsertOneAsync(newCategory);

        public async Task UpdateCategoryAsync(string id, Category updateCategory) =>
            await _categoryCollection.ReplaceOneAsync(x => x.Id == id, updateCategory);

        public async Task RemoveCategoryAsync(string id) =>
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);

    }
}

