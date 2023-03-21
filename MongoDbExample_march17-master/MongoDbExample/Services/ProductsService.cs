//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using MongoDbExample.Models;

//namespace MongoDbExample.Services
//{
//    public class ProductsService
//    {
//        private readonly IMongoCollection<Products> _productsCollection;

//    public ProductsService(
//        IOptions<ProductStoreSetting> productDatabaseSettings)
//    {
//        var mongoClient = new MongoClient(
//            productDatabaseSettings.Value.ConnectionString);

//        var mongoDatabase = mongoClient.GetDatabase(
//            productDatabaseSettings.Value.DatabaseName);

//        _productsCollection = mongoDatabase.GetCollection<Products>(
//            productDatabaseSettings.Value.ProductsCollectionName);
//    }

//    public async Task<List<Products>> GetAsync() =>
//        await _productsCollection.Find(_ => true).ToListAsync();

//    public async Task<Products?> GetAsync(string id) =>
//        await _productsCollection.Find(x => x.id == id).FirstOrDefaultAsync();

//    public async Task CreateAsync(Products newProduct) =>
//        await _productsCollection.InsertOneAsync(newProduct);

//    public async Task UpdateAsync(string id, Products updatedProduct) =>
//        await _productsCollection.ReplaceOneAsync(x => x.id == id, updatedProduct);

//    public async Task RemoveAsync(string id) =>
//        await _productsCollection.DeleteOneAsync(x => x.id == id);

//    }
//    }
