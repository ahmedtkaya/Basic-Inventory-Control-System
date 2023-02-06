using System;
using InventoryControl.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace InventoryControl.Services
{
	public class ProductsService
	{
		private readonly IMongoCollection<Products> _productsCollection;
		private readonly IMongoCollection<Category> _categoryCollection;

		public ProductsService(IOptions<InventoryControlDatabaseSettings> inventoryControlDatabaseSettings)
		{
			var mongoClient = new MongoClient(inventoryControlDatabaseSettings.Value.ConnectionString);
			var mongoDatabase =  mongoClient.GetDatabase(inventoryControlDatabaseSettings.Value.DatabaseName);
			_productsCollection = mongoDatabase.GetCollection<Products>(inventoryControlDatabaseSettings.Value.ProductsCollectionName);
			_categoryCollection = mongoDatabase.GetCollection<Category>(inventoryControlDatabaseSettings.Value.CategoryCollectionName);
		}

		public async Task<List<Products>> GetProductAsync() =>
			await _productsCollection.Find(_ => true).ToListAsync();

        
		public async Task<Products?> GetProductAsync(string id) =>
			await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateProductAsync(Products newProduct) =>
			await _productsCollection.InsertOneAsync(newProduct);

		public async Task UpdateProductAsync(string id, Products updateProduct) =>
			await _productsCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);

		public async Task RemoveProductAsync(string id) =>
			await _productsCollection.DeleteOneAsync(x => x.Id == id);

        

    }
}

