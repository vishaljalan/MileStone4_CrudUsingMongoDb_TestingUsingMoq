using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Models;
using MongoDbExample.Queries;

namespace MongoDbExample.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Products>
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public GetProductByIdHandler(IOptions<ProductStoreSetting> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Products>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<Products> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
            await _productsCollection.Find(x => x.id == request.Id).FirstOrDefaultAsync(cancellationToken);
    }
}
