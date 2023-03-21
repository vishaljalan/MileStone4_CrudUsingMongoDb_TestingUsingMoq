using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Models;
using MongoDbExample.Queries;

namespace MongoDbExample.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Products>>
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public GetProductsHandler(IOptions<ProductStoreSetting> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Products>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<List<Products>> Handle(GetProductsQuery request, CancellationToken cancellationToken) =>
            await _productsCollection.Find(_ => true).ToListAsync(cancellationToken);
    }
}
